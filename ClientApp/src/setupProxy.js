const createProxyMiddleware = require('http-proxy-middleware');
const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:56293';

const context =  [
  "/weatherforecast",
  "/api/categories",
  "/api/companies",
  "/api/employees",
  "/api/movementdetails",
  "/api/movements",
  "/api/products",
  "/api/suppliers",
  "/api/warehouses",
  "/api/warehouseproduct",
  "/api/warehouseproducts"
];

module.exports = function(app) {
  const appProxy = createProxyMiddleware(context, {
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  });

  app.use(appProxy);
};
