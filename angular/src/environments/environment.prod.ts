import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'Framework',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44311',
    redirectUri: baseUrl,
    clientId: 'Framework_App',
    responseType: 'code',
    scope: 'offline_access Framework',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44311',
      rootNamespace: 'Good.Framework',
    },
  },
} as Environment;
