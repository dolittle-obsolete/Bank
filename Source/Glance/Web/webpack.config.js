const path = require('path');
require('dotenv').config();

const webpack = require('@dolittle/typescript.webpack.aurelia').webpack
const originalConfig = webpack(__dirname);

module.exports = () => {
    const config = originalConfig.apply(null, arguments);
    config.devServer = {
        historyApiFallback: true,
        port: 8081,
        proxy: {
          '/api': 'http://localhost:5001',
          '/swagger': 'http://localhost:5001'
        }
      };
    return config;    
};
