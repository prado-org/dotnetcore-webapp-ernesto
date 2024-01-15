param webAppName string
param location string

targetScope = 'subscription'

resource rg 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: 'rg-${webAppName}'
  location: location
}

module acr './ContainerRegistry.bicep' = {
  name: 'acr'
  scope: rg
  params: {
    acrName: format('acr{0}', webAppName)
    location: location
  }
}
