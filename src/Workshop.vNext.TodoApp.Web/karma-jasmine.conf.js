﻿module.exports = function(config) {
    config.set({

        // base path, that will be used to resolve files and exclude
        basePath: 'tests/',

        // frameworks to use
        frameworks: ['jasmine'],

        // Start these browsers
        browsers: ['PhantomJS'],
        
        // list of files / patterns to load in the browser
        files: [
            '../bower_components/jquery/dist/jquery.js',
            '../bower_components/lodash/lodash.js',
            '../tests/**/*.js'
        ]
    });
}
