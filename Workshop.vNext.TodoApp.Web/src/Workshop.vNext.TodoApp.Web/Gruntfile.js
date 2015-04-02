/*
This file in the main entry point for defining grunt tasks and using grunt plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkID=513275&clcid=0x409
*/
module.exports = function (grunt) {
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                }
            }
        },
        
        karma: {
            unit: {
                configFile: 'karma.conf.js'
            }
        },
        
        shell: {
            webHost: {
                options: {
                    async: false
                },
                command: 'k web'
            }
        }
    });

    grunt.loadNpmTasks("grunt-bower-task");
    grunt.loadNpmTasks('grunt-karma');
    grunt.loadNpmTasks('grunt-shell-spawn');   

    grunt.registerTask('run', ['shell:webHost']);
};