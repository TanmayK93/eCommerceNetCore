USE [eCommerce]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019-04-09 3:35:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 2019-04-09 3:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2019-04-09 3:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[ProductId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[rating] [int] NOT NULL,
	[text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2019-04-09 3:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[orderId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[date] [nvarchar](max) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC,
	[UserId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2019-04-09 3:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[image] [nvarchar](max) NULL,
	[price] [decimal](18, 2) NOT NULL,
	[rating] [int] NOT NULL,
	[sale] [nvarchar](max) NULL,
	[discount] [int] NOT NULL,
	[shippingCost] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShippingAddress]    Script Date: 2019-04-09 3:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShippingAddress](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[address1] [nvarchar](max) NULL,
	[address2] [nvarchar](max) NULL,
	[city] [nvarchar](max) NULL,
	[region] [nvarchar](max) NULL,
	[country] [nvarchar](max) NULL,
	[postal] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[defaultaddress] [nvarchar](max) NULL,
	[userID] [int] NOT NULL,
 CONSTRAINT [PK_ShippingAddress] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2019-04-09 3:35:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NULL,
	[email] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190324215738_initial', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190326173829_productv1', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190326174405_productv2', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190331023519_ordertbl', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190331024037_orderv2', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190331025951_orderv3', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190331030530_orderv4', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190331030856_orderv5', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190401232450_userv2', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190401233452_ship3', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190401233522_ship4', N'2.1.3-rtm-32065')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190401234658_ship5', N'2.1.3-rtm-32065')
INSERT [dbo].[Cart] ([UserId], [ProductId], [Quantity]) VALUES (5, 1, 10)
INSERT [dbo].[Order] ([orderId], [UserId], [ProductId], [Quantity], [date]) VALUES (2019011001, 3, 1, 45, N'February 10, 2019')
INSERT [dbo].[Order] ([orderId], [UserId], [ProductId], [Quantity], [date]) VALUES (2019011001, 3, 3, 23, N'February 10, 2019')
INSERT [dbo].[Order] ([orderId], [UserId], [ProductId], [Quantity], [date]) VALUES (2019011002, 3, 4, 20, N'February 11, 2019')
INSERT [dbo].[Order] ([orderId], [UserId], [ProductId], [Quantity], [date]) VALUES (2019011003, 4, 5, 10, N'February 12, 2019')
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [description], [image], [price], [rating], [sale], [discount], [shippingCost]) VALUES (1, N'Elon Musk:Quest for a Fantastic Future
', N'Mr. Vance provides the first inside look into the extraordinary life and times of Silicon Valley\''s most audacious entrepreneur.
', N'https://images-na.ssl-images-amazon.com/images/I/5112YFsXIJL._SX330_BO1,204,203,200_.jpg
', CAST(18.84 AS Decimal(18, 2)), 1, N'yes
', 20, CAST(9.99 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([id], [name], [description], [image], [price], [rating], [sale], [discount], [shippingCost]) VALUES (2, N'The Power of Now: A Guide to Spiritual Enlightenment
', N'The Power of Now is one of the best books to come along in years. Every sentence rings with truth and power.
', N'https://images-na.ssl-images-amazon.com/images/I/41WIbflfG2L.jpg
', CAST(15.74 AS Decimal(18, 2)), 2, N'no
', 30, CAST(6.99 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([id], [name], [description], [image], [price], [rating], [sale], [discount], [shippingCost]) VALUES (3, N'The Alchemist: The Mystical Story of Santiago
', N'Itâ€™s a brilliant, magical, life-changing book that continues to blow my mind with its lessons.
', N'https://images-na.ssl-images-amazon.com/images/I/516c6gUQLaL.jpg
', CAST(13.13 AS Decimal(18, 2)), 3, N'yes', 40, CAST(0.00 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([id], [name], [description], [image], [price], [rating], [sale], [discount], [shippingCost]) VALUES (4, N'Taking the Leap: Freeing Ourselves from Old Habits and Fears
', N'This book gives us the insights and practices we can immediately put to use in our lives to awaken these essential qualities.
', N'https://images-na.ssl-images-amazon.com/images/I/91uYl0dCOoL.jpg
', CAST(15.84 AS Decimal(18, 2)), 4, N'yes', 50, CAST(4.99 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([id], [name], [description], [image], [price], [rating], [sale], [discount], [shippingCost]) VALUES (5, N'The Subtle Art of Not Giving a F*ck
', N'In this generation-defining self-help guide, a superstar blogger cuts through the crap to show us how to stop trying to be "positive" all the time so that we can truly become better, happier people.
', N'https://images-na.ssl-images-amazon.com/images/I/81AM7ZgkeHL.jpg
', CAST(13.19 AS Decimal(18, 2)), 5, N'no', 50, CAST(7.99 AS Decimal(18, 2)))
INSERT [dbo].[Product] ([id], [name], [description], [image], [price], [rating], [sale], [discount], [shippingCost]) VALUES (6, N'The 7 Habits of Highly Effective People: Powerful Lessons in Personal Change
', N'One of the most inspiring and impactful books ever written, The 7 Habits of Highly Effective People has captivated readers for 25 years. It has transformed the lives of Presidents and CEOs, educators and parentsâ€” in short, millions of people of all ages and occupations.
', N'https://images-na.ssl-images-amazon.com/images/I/81jRm4KF2fL.jpg
', CAST(15.20 AS Decimal(18, 2)), 5, N'yes
', 70, CAST(0.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[Product] OFF
SET IDENTITY_INSERT [dbo].[ShippingAddress] ON 

INSERT [dbo].[ShippingAddress] ([id], [name], [address1], [address2], [city], [region], [country], [postal], [phone], [defaultaddress], [userID]) VALUES (1, N'Alan P', N'420 Linden Drive', N'Unit 16', N'Cambridge', N'Ontario', N'Canada', N'N3H 0C6', N'2269894412', N'1', 3)
INSERT [dbo].[ShippingAddress] ([id], [name], [address1], [address2], [city], [region], [country], [postal], [phone], [defaultaddress], [userID]) VALUES (2, N'Alan', N'420 Linden Drive', N'Unit 16', N'Cambridge', N'Ontario', N'Canada', N'N3H 0C6', N'2269894412', N'1', 3)
SET IDENTITY_INSERT [dbo].[ShippingAddress] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [username], [email], [password], [phone]) VALUES (3, N'Alan', N'hp@gmail.com', N'AAAAAQAAJxAAAAAQDyf8dWKS7TrH6nq7QFF4Ld6HItMZ6hywx6Hq6Y6m+7k6pE+7/nhGjs54PpAxWgjA', N'5197221234')
INSERT [dbo].[User] ([id], [username], [email], [password], [phone]) VALUES (4, N'John', N'john@gmail.com', N'AAAAAQAAJxAAAAAQDyf8dWKS7TrH6nq7QFF4Ld6HItMZ6hywx6Hq6Y6m+7k6pE+7/nhGjs54PpAxWgjA', N'5197221255')
INSERT [dbo].[User] ([id], [username], [email], [password], [phone]) VALUES (5, N'Guest', N'guest@gmail.com', N'123456', N'5197221277')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product_ProductId]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_User_UserId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Product_ProductId]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User_UserId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Product_ProductId]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User_UserId]
GO
ALTER TABLE [dbo].[ShippingAddress]  WITH CHECK ADD  CONSTRAINT [FK_ShippingAddress_User_userID] FOREIGN KEY([userID])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[ShippingAddress] CHECK CONSTRAINT [FK_ShippingAddress_User_userID]
GO
