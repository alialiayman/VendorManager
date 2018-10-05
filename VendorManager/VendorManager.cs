using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace VendorManager
{
    public class VendorManager
    {
        public delegate void NotificationEventHandler(object sender, NotificationEventAgrs e);

        public List<IntegrationSetting> AllSettings;
        public List<IntegrationVendorProduct> AllVendorProducts;
        public List<IntegrationSettingType> AllFieldTypes;
        public List<IntegrationProduct> AllProducts;
        public List<IntegrationServiceType> AllServices;
        public List<IntegrationSettingTypeSourceObject> AllSourceFields;
        public List<IntegrationSourceObjectType> AllSources;
        public List<IntegrationVendor> AllVendors;


        public List<VendorManagerLeaf> Services { get; set; }
        public event NotificationEventHandler Notification;

        protected virtual void OnNotification(NotificationEventAgrs e)
        {
            Notification?.Invoke(this, e);
        }

        private void LoadData()
        {
            try
            {
                AllServices = GetServiceTypes();
                AllVendors = GetVendors();
                AllProducts = GetProducts();
                AllVendorProducts = GetVendorProduct();
                AllFieldTypes = GetAllFields();
                AllSources = GetAllSources();
                AllSourceFields = GetAllSourceFields();
                AllSettings = GetallSettings();
            }
            catch (Exception e)
            {
                OnNotification(new NotificationEventAgrs {Message = e.Message});
                throw;
            }

        }

        public List<VendorManagerLeaf> GetVendorManagerTree()
        {
            OnNotification(new NotificationEventAgrs {Message = "Loading Data...."});
            LoadData();
            AppendServices();
            OnNotification(new NotificationEventAgrs {Message = "Services model created....", StatusId = -1});
            AppendVendors();
            OnNotification(new NotificationEventAgrs {Message = "Vendors model created ....", StatusId = -2});
            AddVendorSettings();
            OnNotification(new NotificationEventAgrs {Message = "Vendor settings model created....", StatusId = -3});
            AddVendorProducts();
            OnNotification(new NotificationEventAgrs {Message = "Vendor/Product model created....", StatusId = -4});
            AddVendorProductSettings();
            OnNotification(new NotificationEventAgrs
            {
                Message = "vendor/product settings model created....",
                StatusId = 1
            });
            return Services;
        }

        private void AddVendorProducts()
        {
            foreach (var serviceNode in Services)
            foreach (var vendorNode in serviceNode.Children)
            {
                //Get products for this vendor and insert them above Add new product node
                var vendor = vendorNode.IntegrationVendor;
                if (vendor == null) continue;
                var thisVendorProducts = AllVendorProducts
                    .Where(x => x.IntegrationVendorId == vendor.IntegrationVendorId).ToList();

                foreach (var vendorProduct in thisVendorProducts) //Add products
                {
                    var productNode =
                        new VendorManagerLeaf
                        {
                            LeafText =
                                $"{vendorProduct.IntegrationProductId}-{AllProducts.First(p => p.IntegrationProductId == vendorProduct.IntegrationProductId).Name}",
                            LeafeObject = vendorProduct,
                            IntegrationVendorProduct =
                                vendorProduct, //to avoid type casting in case you already know the type of the leaf
                            IntegrationProduct = AllProducts.FirstOrDefault(x=> x.IntegrationProductId == vendorProduct.IntegrationProductId),
                            LeafImageKey = "P.png",
                            Tooltip =
                                $"IntegrationVendorProductId = {vendorProduct.IntegrationVendorProductId} has IntegrationHelperFQN of {vendorProduct.IntegrationHelperFQN} [IntegrationVendorProduct]"
                        };
                    vendorNode.Children.Insert(0,
                        productNode); //Vendor --> Product, ex. Appraisal -> West VM -> Appraisal
                }
            }
        }

        private void AddVendorProductSettings()
        {
            var vendorProductSource = AllSources.FirstOrDefault(x => x.Name == "INTEGRATION_VENDOR_PRODUCT");
            var vpFields = AllSourceFields.Where(x =>
                x.IntegrationSourceObjectTypeId == vendorProductSource.IntegrationSourceObjectTypeId).ToList();

            var vpSettings = AllSettings.Where(x =>
                vpFields.Select(p=> p.IntegrationSettingTypeSourceObjectId)
                    .Contains(x.IntegrationSettingTypeSourceObjectId.Value)).ToList(); //This is the trickest part because SettingSourceObjectId is a varchar and it could mean a vendor/Product/Environment/Credential etc...
            //Actual fields so we can display the names
            var vendorProductFields = AllFieldTypes.Where(x =>
                vpFields.Select(p => p.IntegrationSettingTypeId).Contains(x.IntegrationSettingTypeId)).ToList();

            foreach (var serviceNode in Services)
            foreach (var vendorNode in serviceNode.Children)
            foreach (var vendorProductNode in vendorNode.Children)
            {
                var thisVendorProduct = vendorProductNode.IntegrationVendorProduct;
                if (thisVendorProduct == null || thisVendorProduct.IntegrationVendorProductId == 0) continue;


                var thisvpSettings = vpSettings.Where(x =>
                    x.SettingSourceObjectId == vendorProductNode.IntegrationVendorProduct.IntegrationVendorProductId.ToString());
                //Now we will go back and get only SourceFields for this vendor
                var thisVendorSourceFields = vpFields.Where(x =>
                    thisvpSettings.Select(p => p.IntegrationSettingTypeSourceObjectId)
                        .Contains(x.IntegrationSettingTypeSourceObjectId)).ToList();

                //Actual fields so we can display the names
                var fields = vendorProductFields.Where(x =>
                    thisVendorSourceFields.Select(p => p.IntegrationSettingTypeId).Contains(x.IntegrationSettingTypeId)).ToList();

                //First add a settings Node to host all settings
                var settingsNode =
                    new VendorManagerLeaf
                    {
                        LeafText = $"Settings [{fields.Count}]",
                        LeafeObject = new IntegrationSourceObjectType { Name = "INTEGRATION_VENDOR_PRODUCT" },
                        ForeColor = Color.Green,
                        LeafImageKey = "SettingsProduct.png",
                        Tooltip =
                            $"Settings for vendor {AllVendors.First(x => x.IntegrationVendorId == thisVendorProduct.IntegrationVendorId).Name} for the product {AllProducts.First(x => x.IntegrationProductId == thisVendorProduct.IntegrationProductId).Name} [IntegrationSourceObjectType]"
                    }; //Add product setting this should be a settings object with some ids added to it


                        foreach (var field in fields)
                {
                            var vendorSourceField =  thisVendorSourceFields.FirstOrDefault(x=> x.IntegrationSettingTypeId ==  field.IntegrationSettingTypeId); //get this field
                    var setting = AllSettings.FirstOrDefault(x =>
                        x.SettingSourceObjectId == thisVendorProduct.IntegrationVendorProductId.ToString() &&
                        x.IntegrationSettingTypeSourceObjectId ==
                        vendorSourceField.IntegrationSettingTypeSourceObjectId);

                            var actualSettingNode =
                        new VendorManagerLeaf
                        {
                            LeafText = $"{field.IntegrationSettingTypeId}-{field.Name}",
                            LeafeObject = field,
                            IntegrationSetting = setting, // add the correct integration setting here so you can edit it easier in the future 
                            IntegrationSettingType =
                                field, //to avoid type casting in case you already know the type of the field
                            ForeColor = Color.Green,
                            BackColor = Color.Snow,
                            LeafImageKey = "SettingsProduct.png",
                            Tooltip =
                                $"IntegrationSettingTypeId = {field.IntegrationSettingTypeId} is {field.Descr} of type {field.DataEntryType} and has a default value of {field.DefatulValue} [IntegrationSettingType]"
                        };

                    settingsNode.Children.Add(actualSettingNode);
                }


                var addnewVendorSetting =
                    new VendorManagerLeaf
                    {
                        LeafText =
                            $"Add new vendor product setting to ({AllVendors.First(x => x.IntegrationVendorId == thisVendorProduct.IntegrationVendorId).Name}) vendor -  ({AllProducts.First(x => x.IntegrationProductId == thisVendorProduct.IntegrationProductId).Name}) product",
                        LeafeObject = new IntegrationSetting(),
                        ForeColor = Color.Green,
                        BackColor = Color.Snow,
                        LeafImageKey = "AddProduct.png",
                        Tooltip =
                            $"Add new setting {AllVendors.First(x => x.IntegrationVendorId == thisVendorProduct.IntegrationVendorId).Name} for the product {AllProducts.First(x => x.IntegrationProductId == thisVendorProduct.IntegrationProductId).Name} [IntegrationSetting]"
                    }; //Add product setting this should be a settings object with some ids added to it
                settingsNode.Children.Add(addnewVendorSetting);

                vendorProductNode.Children.Add(settingsNode);
                        OnNotification(new NotificationEventAgrs {Message = $"Vendor Product Settings modeled for {vendorNode.IntegrationVendor.Name}/{AllProducts.First(x=> x.IntegrationProductId == vendorProductNode.IntegrationVendorProduct.IntegrationProductId).Name} {fields.Count} Settings added"});
            }
        }

        private void AppendServices()
        {
            Services = new List<VendorManagerLeaf>();
            foreach (var service in AllServices)
            {
                var newServiceNode =
                    new VendorManagerLeaf
                    {
                        LeafText = $"{service.IntegrationServiceTypeId}-{service.Name}",
                        LeafeObject = service,
                        IntegrationServiceType =
                            service, //To avoid reflection of type casting if you already know the type of the leaf
                        Tooltip =
                            $"IntegrationServiceTypeId = {service.IntegrationServiceTypeId} is {service.Descr} [IntegrationServiceType]",
                        LeafImageKey = "blank.png"
                    };
                Services.Add(newServiceNode);
            }
            ShowAddNewServiceNode();
        }

        private void ShowAddNewServiceNode()
        {
            var clickToAddNewServiceNode = new VendorManagerLeaf
            {
                LeafText = $"Add new service",
                LeafeObject = new IntegrationServiceType {IntegrationServiceTypeId = 0},
                ForeColor = Color.Black,
                LeafImageKey = "AddService.png",
                Tooltip = $"Add new service to iMP [IntegrationServiceTypeId]"
            };
            Services.Add(clickToAddNewServiceNode);
        }


        private void AppendVendors()
        {
            foreach (var serviceNode in Services)
                AppendVendors(serviceNode);
        }

        private void AppendVendors(VendorManagerLeaf serviceNode)
        {
            var currentService = serviceNode.IntegrationServiceType;
            if (currentService == null || currentService.IntegrationServiceTypeId == 0) return;

            var relatedProducts =
                AllProducts.Where(x => x.IntegrationServiceTypeId == currentService.IntegrationServiceTypeId)
                    .Select(x => x.IntegrationProductId).ToList();
            var relatedVendorProducts = AllVendorProducts
                .Where(x => relatedProducts.Contains(x.IntegrationProductId.Value))
                .ToList();

            var thisServiceVendors = AllVendors.Where(p =>
                relatedVendorProducts.Select(x => x.IntegrationVendorId).Contains(p.IntegrationVendorId));
            foreach (var vendor in thisServiceVendors) //add vendors
            {
                var vendorNode =
                    new VendorManagerLeaf

                    {
                        LeafText = $"{vendor.IntegrationVendorId}-{vendor.Name}",
                        LeafeObject = vendor,
                        IntegrationVendor =
                            vendor, //to avoid type casting in case you already know the type of the leaf
                        ForeColor = Color.Blue,
                        LeafImageKey = "V.jpg",
                        Tooltip =
                            $"IntegrationVendorId = {vendor.IntegrationVendorId} is {vendor.Descr} using Scheme {vendor.SchemaType} [IntegrationVendor]"
                    };

                serviceNode.Children.Add(vendorNode);
                ShowAddNewVendorProductNode(vendorNode);
            }

            ShowAddNewVendorNode(serviceNode);
        }


        private void ShowAddNewVendorProductNode(VendorManagerLeaf vendorNode)
        {
            var vendor = vendorNode.LeafeObject as IntegrationVendor;
            var addproductNode =
                new VendorManagerLeaf
                {
                    LeafText =
                        $"Add new product to ({vendor.Name}) vendor", //{(vendorNode.Parent.Tag as IntegrationServiceType).Name} 
                    LeafeObject = new IntegrationVendorProduct(),
                    ForeColor = Color.Green,
                    LeafImageKey = "AddProduct.png",
                    Tooltip = $"Add new vendor product to {vendor.Name} [IntegrationVendorProduct]"
                };
            vendorNode.Children.Add(addproductNode);
        }


        private void ShowAddNewVendorNode(VendorManagerLeaf serviceNode)
        {
            var service = serviceNode.LeafeObject as IntegrationServiceType;
            var clickToAddNewVendorNode =
                new VendorManagerLeaf
                {
                    LeafText = $"Add new vendor to ({service.Name}) service",
                    LeafeObject = new IntegrationVendor(),
                    ForeColor = Color.Blue,
                    LeafImageKey = "AddVendor.png",
                    Tooltip = $"Add new vendor to {service.Name} [IntegrationVendor]"
                };
            serviceNode.Children.Add(clickToAddNewVendorNode);
        }


        private void AddVendorSettings()
        {
            var vendorSource = AllSources.FirstOrDefault(x => x.Name == "INTEGRATION_VENDOR");
            var vendorSourceFields = AllSourceFields.Where(x =>
                x.IntegrationSourceObjectTypeId == vendorSource.IntegrationSourceObjectTypeId).ToList();

            var vendorSettings = AllSettings.Where(x =>
                vendorSourceFields.Select(p => p.IntegrationSettingTypeSourceObjectId)
                    .Contains(x.IntegrationSettingTypeSourceObjectId.Value)).ToList(); //This is the trickest part because SettingSourceObjectId is a varchar and it could mean a vendor/Product/Environment/Credential etc...


            foreach (var serviceNode in Services)
            {
                foreach (var vendorNode in serviceNode.Children)
                {
                    var thisVendor = vendorNode.IntegrationVendor;

                    if (thisVendor == null || thisVendor.IntegrationVendorId == 0) continue;
                    //if (serviceNode.IntegrationServiceType.IntegrationServiceTypeId == 20) Debugger.Break();


                    //Now get this vendor settings - Many settings
                    var thisVendorSettings = vendorSettings.Where(x =>
                        x.SettingSourceObjectId ==
                        thisVendor.IntegrationVendorId
                            .ToString()); //This is the trickest part because SettingSourceObjectId is a varchar and it could mean a vendor/Product/Environment/Credential etc...

                    //Now we will go back and get only SourceFields for this vendor - Many fields
                    //Many fields
                    var thisVendorSourceFields = AllSourceFields.Where(x =>
                        thisVendorSettings.Select(p => p.IntegrationSettingTypeSourceObjectId)
                            .Contains(x.IntegrationSettingTypeSourceObjectId)).ToList();

                    //Actual fields so we can display the names
                    var fields = AllFieldTypes.Where(x =>
                        thisVendorSourceFields.Select(p => p.IntegrationSettingTypeId).Contains(x.IntegrationSettingTypeId)).ToList();

                    //First add a settings Node to host all settings
                    var settingsNode =
                        new VendorManagerLeaf
                        {
                            LeafText = $"Settings [{fields.Count()}]",
                            LeafeObject = new IntegrationSourceObjectType { Name = "INTEGRATION_VENDOR" },
                            ForeColor = Color.Blue,
                            LeafImageKey = "SettingsVendor.png",
                            Tooltip = $"Settings for vendor {thisVendor.Name} [IntegrationSourceObjectType]"
                        };


                    foreach (var field in fields)
                    {

                        var vendorSourceField = thisVendorSourceFields.FirstOrDefault(x => x.IntegrationSettingTypeId == field.IntegrationSettingTypeId); //get this field
                        var setting = AllSettings.FirstOrDefault(x =>
                            x.SettingSourceObjectId == thisVendor.IntegrationVendorId.ToString() &&
                            x.IntegrationSettingTypeSourceObjectId ==
                            vendorSourceField.IntegrationSettingTypeSourceObjectId);

                        var actualSettingNode =
                            new VendorManagerLeaf
                            {
                                LeafText = $"{field.IntegrationSettingTypeId}-{field.Name}",
                                LeafeObject = field,
                                IntegrationSettingType =
                                    field, //to avoid type casting in case you already know the type of the leaf,
                                IntegrationSetting = setting,
                                ForeColor = Color.Blue,
                                BackColor = Color.Snow,
                                LeafImageKey = "SettingsVendor.png",
                                Tooltip =
                                    $"IntegrationSettingTypeId = {field.IntegrationSettingTypeId} is {field.Descr} of type {field.DataEntryType} and has a default value of {field.DefatulValue} [IntegrationSettingType]"
                            };

                        settingsNode.Children.Add(actualSettingNode);
                    }


                    var addnewVendorSetting =
                        new VendorManagerLeaf
                        {
                            LeafText = $"Add new vendor setting to ({thisVendor.Name}) vendor",
                            LeafeObject = new IntegrationSetting(),
                            ForeColor = Color.Blue,
                            BackColor = Color.Snow,
                            LeafImageKey = "AddVendor.png",
                            Tooltip = $"Add new vendor setting to {thisVendor.Name} [IntegrationSetting]"
                        }; //Add product setting this should be a settings object with some ids added to it
                    settingsNode.Children.Add(addnewVendorSetting);

                    vendorNode.Children.Add(settingsNode);
                }
            }
        }


        public int AddService(IntegrationServiceType input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                dc.IntegrationServiceTypes.InsertOnSubmit(input);
                dc.SubmitChanges();
            }
            return input.IntegrationServiceTypeId;
        }

        public int MaxServiceId()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return  dc.IntegrationServiceTypes.Max(x => x.IntegrationServiceTypeId) + 1;
            }
        }

        public int AddVendor(IntegrationVendor input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var vendorSameNameOrCode =
                    dc.IntegrationVendors.FirstOrDefault(x => x.Name == input.Name || x.Code == input.Code);

                if (vendorSameNameOrCode != null)
                {
                    input.IntegrationVendorId = vendorSameNameOrCode.IntegrationVendorId;
                }
                else
                {
                    var maxId = dc.IntegrationVendors.Max(x => x.IntegrationVendorId);
                    input.IntegrationVendorId = maxId + 1;
                    dc.IntegrationVendors.InsertOnSubmit(input);
                    dc.SubmitChanges();
                }

            }

            return input.IntegrationVendorId;
        }

        public int AddProduct(IntegrationProduct input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var maxId = dc.IntegrationProducts.Max(x => x.IntegrationProductId);
                input.IntegrationProductId = maxId + 1;
                dc.IntegrationProducts.InsertOnSubmit(input);
                dc.SubmitChanges();
            }

            return input.IntegrationProductId;
        }

        public int AssociateProductToVendor(IntegrationVendorProduct input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var maxId = dc.IntegrationVendorProducts.Max(x => x.IntegrationVendorProductId);
                input.IntegrationVendorProductId = maxId + 1;
                dc.IntegrationVendorProducts.InsertOnSubmit(input);
                dc.SubmitChanges();
            }

            return input.IntegrationVendorProductId;
        }

        public int AddTextIntegrationSettingType(IntegrationSettingType input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var maxId = dc.IntegrationSettingTypes.Max(x => x.IntegrationSettingTypeId);
                input.IntegrationSettingTypeId = ++maxId;
                dc.SubmitChanges();
            }

            return input.IntegrationSettingTypeId;
        }


        public List<IntegrationServiceType> GetServiceTypes()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return dc.IntegrationServiceTypes.ToList();
            }
        }

        public List<IntegrationVendor> GetVendors()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return dc.IntegrationVendors.ToList();
            }
        }

        public List<IntegrationProduct> GetProducts()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return dc.IntegrationProducts.ToList();
            }
        }

        public List<IntegrationVendorProduct> GetVendorProduct()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return dc.IntegrationVendorProducts.ToList();
            }
        }

        public void DeleteService(IntegrationServiceType input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var toDelete =
                    dc.IntegrationServiceTypes.Where(x => x.IntegrationServiceTypeId == input.IntegrationServiceTypeId);
                var toDeleteProducts =
                    dc.IntegrationProducts.Where(x => x.IntegrationServiceTypeId == input.IntegrationServiceTypeId);
                var toDeleteVendorProduct = dc.IntegrationVendorProducts.Where(x =>
                    toDeleteProducts.Select(a => a.IntegrationProductId).Contains(x.IntegrationProductId.Value));
                dc.IntegrationVendorProducts.DeleteAllOnSubmit(toDeleteVendorProduct);
                dc.IntegrationProducts.DeleteAllOnSubmit(toDeleteProducts);
                dc.IntegrationServiceTypes.DeleteAllOnSubmit(toDelete);
                dc.SubmitChanges();
            }
        }

        public void DeleteVendor(IntegrationVendor input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var toDelete = dc.IntegrationVendors.Where(x => x.IntegrationVendorId == input.IntegrationVendorId);
                var toDeleteVendorProducts =
                    dc.IntegrationVendorProducts.Where(x => x.IntegrationVendorId == input.IntegrationVendorId);
                dc.IntegrationVendorProducts.DeleteAllOnSubmit(toDeleteVendorProducts);
                dc.IntegrationVendors.DeleteAllOnSubmit(toDelete);
                dc.SubmitChanges();
            }
        }

        public List<IntegrationSettingType> GetAllFields()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                dc.DeferredLoadingEnabled = false;
                return dc.IntegrationSettingTypes.ToList();
            }
        }

        public List<IntegrationSourceObjectType> GetAllSources()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                dc.DeferredLoadingEnabled = false;
                return dc.IntegrationSourceObjectTypes.ToList();
            }
        }

        public List<IntegrationSettingTypeSourceObject> GetAllSourceFields()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                dc.DeferredLoadingEnabled = false;
                return dc.IntegrationSettingTypeSourceObjects.ToList();
            }
            
        }

        public List<IntegrationSetting> GetallSettings()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                dc.DeferredLoadingEnabled = false;
                return dc.IntegrationSettings.Where(x=> x.IntegrationSettingTypeSourceObjectId != null && x.SettingSourceObjectId != null && x.SettingSourceObjectId != "").ToList();
            }
        }

        public void DeleteProduct(IntegrationProduct input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var toDelete = dc.IntegrationProducts.Where(x => x.IntegrationProductId == input.IntegrationProductId);
                var toDeleteVendorProducts =
                    dc.IntegrationVendorProducts.Where(x => x.IntegrationProductId == input.IntegrationProductId);
                dc.IntegrationVendorProducts.DeleteAllOnSubmit(toDeleteVendorProducts);
                dc.IntegrationProducts.DeleteAllOnSubmit(toDelete);
                dc.SubmitChanges();
            }
        }

        public int AddSettingType(IntegrationSettingType newSetting)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                dc.IntegrationSettingTypes.InsertOnSubmit(newSetting);
                dc.SubmitChanges();
            }

            return newSetting.IntegrationSettingTypeId;
        }

        public int AddSetting(IntegrationSetting input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var maxId = dc.IntegrationSettings.Max(x => x.IntegrationSettingId);
                input.IntegrationSettingId = maxId + 1;

                dc.IntegrationSettings.InsertOnSubmit(input);
                dc.SubmitChanges();
            }

            return input.IntegrationSettingId;
        }

        public int AssociateSettingToSource(IntegrationSettingTypeSourceObject input)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var existingSourceField = dc.IntegrationSettingTypeSourceObjects.FirstOrDefault(x =>
                    x.IntegrationSettingTypeId == input.IntegrationSettingTypeId &&
                    x.IntegrationSourceObjectTypeId == input.IntegrationSourceObjectTypeId);

                if (existingSourceField != null)
                {
                    input.IntegrationSettingTypeSourceObjectId =
                        existingSourceField.IntegrationSettingTypeSourceObjectId;
                    return existingSourceField.IntegrationSettingTypeSourceObjectId;
                }
                else
                {
                    var maxId = dc.IntegrationSettingTypeSourceObjects.Max(x => x.IntegrationSettingTypeSourceObjectId);
                    input.IntegrationSettingTypeSourceObjectId = maxId + 1;
                    dc.IntegrationSettingTypeSourceObjects.InsertOnSubmit(input);
                    dc.SubmitChanges();
                }
            }

            return input.IntegrationSettingTypeSourceObjectId;
        }

        public void SaveService(IntegrationServiceType service)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var dbService = dc.IntegrationServiceTypes.FirstOrDefault(x =>
                    x.IntegrationServiceTypeId == service.IntegrationServiceTypeId);
                if (dbService != null)
                {
                    dbService.Name = service.Name;
                    dbService.Descr = service.Descr;
                }
                dc.SubmitChanges();
            }
        }

        public void SaveVendor(IntegrationVendor vendor)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var dbVendor =
                    dc.IntegrationVendors.FirstOrDefault(x => x.IntegrationVendorId == vendor.IntegrationVendorId);
                if (dbVendor != null)
                {
                    dbVendor.Name = vendor.Name;
                    dbVendor.Descr = vendor.Descr;
                    dbVendor.Code = vendor.Code;
                    dbVendor.SchemaType = vendor.SchemaType;
                }
                dc.SubmitChanges();
            }
        }

        public void SaveProduct(IntegrationProduct product)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var dbProduct =
                    dc.IntegrationProducts.FirstOrDefault(x => x.IntegrationProductId == product.IntegrationProductId);
                if (dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.Descr = product.Descr;
                    dbProduct.Code = product.Code;
                }
                dc.SubmitChanges();
            }
        }

        public void SaveVendorProduct(IntegrationVendorProduct vendorProduct)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var dbVendorProduct = dc.IntegrationVendorProducts.FirstOrDefault(x =>
                    x.IntegrationVendorProductId == vendorProduct.IntegrationVendorProductId);
                if (dbVendorProduct != null)
                {
                    dbVendorProduct.IntegrationHelperFQN = vendorProduct.IntegrationHelperFQN;
                    dbVendorProduct.SimulatorURL = vendorProduct.SimulatorURL;
                }
                else
                {
                    vendorProduct.IntegrationVendorProductId =
                        dc.IntegrationVendorProducts.Max(x => x.IntegrationVendorProductId);
                    dc.IntegrationVendorProducts.InsertOnSubmit(vendorProduct);
                }
                dc.SubmitChanges();
            }
        }

        //private string _connectionString = @"Data Source=CLODEV01SSQL01.cloudvirga.local\TRUNK126;Initial Catalog=Services;User ID=MMLSQLApp;Password=!P@ssw0rd1234#;Application Name=TRUNK115Services";
        private string _connectionString = @"Data Source=CLODEV01SSQL01.cloudvirga.local\TRUNK126;Initial Catalog=Services;Integrated Security=true;Application Name=TRUNK115Services";
        public void SetConnection(string input)
        {
            var serverAddress = string.Join(",",input.Split(',').Skip(1));
            _connectionString = Regex.Replace(_connectionString, @"^Data Source=(.*?);(.*)$", $"Data Source={serverAddress};$2");
        }

        public void SaveSettingType(IntegrationSettingType vendorSettingType)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var dbVendorSetting= dc.IntegrationSettingTypes.FirstOrDefault(x =>
                    x.IntegrationSettingTypeId == vendorSettingType.IntegrationSettingTypeId);
                if (dbVendorSetting != null)
                {
                    dbVendorSetting.Name = vendorSettingType.Name;
                    dbVendorSetting.Code = vendorSettingType.Code;
                    dbVendorSetting.DataEntryType = vendorSettingType.DataEntryType;
                    dbVendorSetting.DefatulValue = vendorSettingType.DefatulValue;
                    dbVendorSetting.Descr = vendorSettingType.Descr;
                    dbVendorSetting.Restrictions = vendorSettingType.Restrictions;


                }
                dc.SubmitChanges();
            }
        }

        public int MaxVendorId()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return dc.IntegrationVendors.Max(x => x.IntegrationVendorId) + 1;
            }
        }

        public int MaxProductId()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return dc.IntegrationProducts.Max(x => x.IntegrationProductId) + 1;
            }
        }

        public int MaxFieldId()
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                return dc.IntegrationSettingTypes.Max(x => x.IntegrationSettingTypeId) + 1;
            }
        }


        public void SaveSetting(IntegrationSetting setting)
        {
            using (var dc = new VendorDataContext(_connectionString))
            {
                var existingSettin =
                    dc.IntegrationSettings.FirstOrDefault(x => x.IntegrationSettingId == setting.IntegrationSettingId);
                existingSettin.Value = setting.Value;
                dc.SubmitChanges();
            }
        }


        public string GenerateSql(object inputObject)
        {
            var members = inputObject.GetType().GetProperties();
            var srCheckNames = new StringBuilder($"{new String('-', 15)} {inputObject.GetType().Name}  table [BEGIN] {new String('-', 15)} \n\nIF NOT EXISTS (SELECT 1 FROM {inputObject.GetType().Name} WHERE ");

            var srInsertNames = new StringBuilder($"\n\nINSERT INTO {inputObject.GetType().Name} (");
            var srInsertValues = new StringBuilder($"VALUES (");
            foreach (var member in members)
            {
                if (member.PropertyType.FullName.Contains("System.Data.Linq") || member.PropertyType.FullName == inputObject.GetType().Name || member.PropertyType.FullName == "VendorManager.IntegrationVendor" || member.PropertyType.FullName == "VendorManager.IntegrationProduct") continue;
                srInsertNames.Append($"[{member.Name}],");
                srCheckNames.Append($"[{member.Name}] = ");
                if (member.PropertyType.FullName.Contains("Int32") || member.PropertyType.FullName.Contains("Int16") || member.PropertyType.FullName.Contains("Boolean"))
                {
                    var  val = member.GetValue(inputObject);
                    if (val == null)
                        val = "null";
                    else if (val.ToString() == "True")
                        val = 1;
                    srInsertValues.Append($"{val},");
                    srCheckNames.Append($"{val}  AND ");
                }
                else
                {
                    srInsertValues.Append($"'{member.GetValue(inputObject)}',");
                    srCheckNames.Append($"'{member.GetValue(inputObject)}' AND ");
                }
            }

            return srCheckNames.ToString().Substring(0, srCheckNames.ToString().Length - "AND ".Length) + ")\n BEGIN \n " +  srInsertNames.ToString().TrimEnd(',') + ") " + srInsertValues.ToString().TrimEnd(',') + $");\nEND\n{new String('-',15)} {inputObject.GetType().Name}  table [END] {new String('-', 15)}\n\n";

        }

        public List<IntegrationServiceType> GetOrphanServices()
        {
            return AllServices.Where(p =>
                !AllProducts.Select(x => x.IntegrationServiceTypeId).Contains(p.IntegrationServiceTypeId)).ToList();
        }

        public List<IntegrationProduct> GetOrphanProducts()
        {
            return AllProducts.Where(p =>
                !AllVendorProducts.Select(x => x.IntegrationProductId).Contains(p.IntegrationProductId)).ToList();
        }

        public List<IntegrationVendor> GetOrphanVendors()
        {
            return AllVendors.Where(p =>
                !AllVendorProducts.Select(x => x.IntegrationVendorId).Contains(p.IntegrationVendorId)).ToList();
        }

        public List<IntegrationSettingType> GetOrphanSettingTypes()
        {
            return AllFieldTypes.Where(p =>
                !AllSourceFields.Select(x => x.IntegrationSettingTypeId).Contains(p.IntegrationSettingTypeId)).ToList();
        }
    }
}