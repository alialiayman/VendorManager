update UserAccount set IsLocked = 0 , NumberOfFailedAttempts = 0
where IsLocked = 1

update useraccount set [password] = 'AE9A6928A91185BF42A5D3FE43081081D8660E10B0BDA43F995B08EAE7B8C76B9A2AB6FA7FBE5B988D0C8F73212F564BBC211896DC2F3A62A5F30433D76F9D80' 
where Username like 'custom83447@mail.com%'