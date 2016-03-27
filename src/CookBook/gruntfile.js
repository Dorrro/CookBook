/// <binding ProjectOpened='bower:install' />
module.exports = function (grunt) {
    grunt.initConfig({
        bower: {
            install: {
                options: {
                    targetDir: "wwwroot/lib",
                    layout: "byComponent",
                    verbose: true,
                    install: true,
                    bowerOptions: {}
                }
            }
        }
    });

    grunt.loadNpmTasks("grunt-bower-task");
};