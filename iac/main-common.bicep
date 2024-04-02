param acrName string
param webAppName string
param location string

targetScope = 'subscription'

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: 'rg-${acrName}'
  location: location
}

module acr './containerRegistry.bicep' = {
  name: 'acr'
  scope: rg
  params: {
    acrName: format('acr{0}', acrName)
    location: location
  }
}

module sqlServer './sqlServer.bicep' = {
  name: 'sqlServer'
  scope: rg
  params: {
    sqlServerName: 'sql-${webAppName}'
    sqlAdministratorLogin: 'sqladmin'
    sqlAdministratorLoginPassword: '#P@ssw0rd123456#'
    sqlDatabaseName: 'db-${webAppName}'
    location: location
  }
}
