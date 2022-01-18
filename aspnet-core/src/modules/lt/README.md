# Localization Management

本地化文档管理模块,因项目路径太长Windows系统不支持,项目目录取简称 lt  

## 模块说明

### 基础模块

* [GoodFramework.Abp.Localization.Dynamic](../common/GoodFramework.Abp.Localization.Dynamic/GoodFramework.Abp.Localization.Dynamic)					本地化扩展模块,增加 DynamicLocalizationResourceContributor 通过 ILocalizationStore 接口获取动态的本地化资源信息  
* [GoodFramework.Abp.LocalizationManagement.Domain.Shared](./GoodFramework.Abp.LocalizationManagement.Domain.Shared)					领域层公共模块，定义了错误代码、本地化、模块设置  
* [GoodFramework.Abp.LocalizationManagement.Domain](./GoodFramework.Abp.LocalizationManagement.Domain)								领域层模块，实现 ILocalizationStore 接口  
* [GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore](./GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore)								数据访问层模块,集成EfCore  
* [GoodFramework.Abp.LocalizationManagement.Application.Contracts](./GoodFramework.Abp.LocalizationManagement.Application.Contracts)	应用服务层公共模块，定义了管理本地化对象的外部接口、权限、功能限制策略  
* [GoodFramework.Abp.LocalizationManagement.Application](./GoodFramework.Abp.LocalizationManagement.Application)						应用服务层实现，实现了本地化对象管理接口  
* [GoodFramework.Abp.LocalizationManagement.HttpApi](./GoodFramework.Abp.LocalizationManagement.HttpApi)								RestApi实现，实现了独立的对外RestApi接口  

### 高阶模块

### 权限定义

* LocalizationManagement.Resource						授权对象是否允许访问资源  
* LocalizationManagement.Resource.Create		授权对象是否允许创建资源  
* LocalizationManagement.Resource.Update		授权对象是否允许修改资源  
* LocalizationManagement.Resource.Delete		授权对象是否允许删除资源  
* LocalizationManagement.Language						授权对象是否允许访问语言  
* LocalizationManagement.Language.Create		授权对象是否允许创建语言  
* LocalizationManagement.Language.Update		授权对象是否允许修改语言  
* LocalizationManagement.Language.Delete		授权对象是否允许删除语言  
* LocalizationManagement.Text						    授权对象是否允许访问文档  
* LocalizationManagement.Text.Create				授权对象是否允许创建文档  
* LocalizationManagement.Text.Update				授权对象是否允许删除Oss对象  
* LocalizationManagement.Text.Delete				授权对象是否允许下载Oss对象  

### 功能定义

### 配置定义

## 更新日志

