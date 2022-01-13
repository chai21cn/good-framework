import { defHttp } from '/@/utils/http/axios';
import { IApplicationConfiguration } from './model/appModel';
import { ApplicationApiDescriptionModel } from './model/apiDefinition';

enum Api {
  ApplicationConfiguration = '/abp/application-configuration',
  ApiDefinition = '/abp/api-definition',
}

export const getApplicationConfiguration = () => {
  return defHttp.get<IApplicationConfiguration>({
    url: Api.ApplicationConfiguration,
  });
};

export const getApiDefinition = (includeTypes = false) => {
  return defHttp.get<ApplicationApiDescriptionModel>({
    url: Api.ApiDefinition,
    params: { includeTypes: includeTypes },
  });
};
