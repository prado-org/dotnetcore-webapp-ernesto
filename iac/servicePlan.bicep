param planName string
param location string
param sku string

resource appServicePlan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: planName
  location: location
  sku: {
    name: sku
  }
  kind: 'linux'
  properties: {
    reserved: true
  }
}

output servicePlanName string = appServicePlan.name
output servicePlanId string = appServicePlan.id
