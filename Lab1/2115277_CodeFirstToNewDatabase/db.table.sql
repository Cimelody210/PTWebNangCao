CREATE TABLE [dbo].[Blogs] ( 
    [BlogId] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
    [Url]  NVARCHAR (200) NULL, 
    CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED ([BlogId] ASC) 
); 
  
CREATE TABLE [dbo].[Posts] ( 
    [PostId] INT IDENTITY (1, 1) NOT NULL, 
    [Title] NVARCHAR (200) NULL, 
    [Content] NTEXT NULL, 
    [BlogId] INT NOT NULL, 
    CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED ([PostId] ASC), 
    CONSTRAINT [FK_dbo.Posts_dbo.Blogs_BlogId] FOREIGN KEY ([BlogId]) 
 
REFERENCES [dbo].[Blogs] ([BlogId]) ON DELETE CASCADE
);
--b. Thêm mới dữ liệu cho bảng Blog thông qua các câu lệnh: 
insert into [dbo].[Blogs] values(1,'Văn hóa')
insert into [dbo].[Blogs] values(2,'Xã hội')
insert into [dbo].[Blogs] values(3,'Tự nhiên')
insert into [dbo].[Blogs] values(4,'Kinh tế')

--c. Thêm dữ liệu cho bảng Post 
insert into [dbo].[Posts] values(1,'Bóng đá Việt Nam thay huấn luyện viên ','Ông Nguyễn Hữu Thắng trở thành tân huấn luyện viên tuyển Việt Nam',1)
insert into [dbo].[Posts] values(2,'Tiêm phòng vắc xin bệnh dại','Tiêm phòng ngày 25/02/2012',2)
insert into [dbo].[Posts] values(3,'Tin tự nhiên','Tin tự nhiên',2)
insert into [dbo].[Posts] values(4,'ABC','DEF',4)