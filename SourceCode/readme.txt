使用本系统前请仔细阅读本文档

环境的安装
1.安装好MicrosoftVisioStudio2017版本

数据库的安装
1.安装好SQLServer
2.打开SQL Server Management Studio，对象资源管理器中数据库选项->右键还原数据库->源 点击设备->点击右侧更多按钮(...)->
  弹出框点击添加按钮->找到Ordance所在的文件夹->文件名称右侧选择所有文件->选中Ordance文件后点击确定->选中点击确定->
  此时页面自动回退 点击确定
3.安装好VS后 双击Ordance.sln文件，找到App_Start文件夹下的DBHelper.cs文件，GetCon()方法下的修改server为你的服务器名称
  和database为你的数据库名称Ordance

浏览器的安装
1.建议使用IE浏览器或者QQ浏览器

系统的运行
以上安装完成后，打开VS，点击IIS Express即刻运行。