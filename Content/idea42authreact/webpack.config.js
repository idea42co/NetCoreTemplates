var path = require('path');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var HtmlWebpackPlugin = require('html-webpack-plugin');

const extractSass = new ExtractTextPlugin({
    filename: "[name].[contenthash].css",
    disable: process.env.NODE_ENV === "development"
});

module.exports = {
    entry: ['./App/index.js'],
    module: {
        rules: [
            { test: /\.js$/, loader: 'babel-loader', query: { presets: ['env', 'react'] }, exclude: /node_modules/ },
            { test: /\.css$/, loader: ExtractTextPlugin.extract({ fallback: 'style-loader', use: 'css-loader' }) },
            { test: /\.scss$/, use: ExtractTextPlugin.extract({ use: [{ loader: "css-loader" }, { loader: "sass-loader" }], fallback: "style-loader" }) },
            {
                test: /\.(jpe?g|png|gif|svg)$/i, loaders: ['file-loader?hash=sha512&digest=hex&name=images/[hash].[ext]', {
                    loader: 'image-webpack-loader',
                    query: {
                        gifsicle: {
                            interlaced: false,
                        },
                        optipng: {
                            optimizationLevel: 4,
                        },
                        pngquant: {
                            quality: '75-90',
                            speed: 3,
                        },
                    }
                }]
            }
        ]
    },
    plugins: [
        new ExtractTextPlugin({
            filename: "bundle.css",
            disable: false,
            allChunks: true
        })
    ],
    output: {
        filename: 'bundle.js',
        path: path.join(__dirname, '/wwwroot/')
    }
}