/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib"
                }
            }
        },

        karma: {
            options: {
                configFile: "karma-jasmine.conf.js"
            },
            unit: {
                singleRun: true
            },
            continuous: {
                singleRun: false,
                background: true
            }
        },

        watch: {
            karma: {
                files: ["**/*.cs", "**/*.cshtml", "**/*.js"],
                tasks: ["karma:continuous:run"]
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-watch");
    grunt.loadNpmTasks("grunt-bower-task");
    grunt.loadNpmTasks("grunt-karma");

    grunt.registerTask("test", ["karma:continuous:start", "watch:karma"]);
};