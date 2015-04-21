
"use strict";
describe("Todos API", function () {

    var self = this;
    describe("GET /Todos", function() {
        var todoTasks = [];

        beforeEach(function(done) {
            $.get("http://localhost:5001/Todos", function(data) {
                    todoTasks = data;
                }).fail(function(data) {
                    console.info(JSON.stringify(data));
                })
                .always(function() {
                    done();
                });
        });

        it("returns data", function() {
            expect(todoTasks.length).toBeGreaterThan(0);
        });
    });

    describe("POST /Todos", function () {
        var todoTasks = [];
        var testId = (new Date()).getTime() % 10000;

        beforeEach(function(done) {
            $.ajax({
                url: "http://localhost:5001/Todos",
                data: JSON.stringify({ id: testId, task: "Test Task" }),
                success: function () {
                    console.info("Posted");
                    $.get("http://localhost:5001/Todos", function(data) { todoTasks = data; })
                        .always(function() { done(); });
                },
                contentType: "application/json; charset=UTF-8",
                type: "POST"
            });
        });

        it("adds data", function () {
            console.info(todoTasks);
            var retrievedTask = _.findWhere(todoTasks, { id: testId });
            expect(retrievedTask.id).toBe(testId);

        });
    });

    describe("DELETE /Todos", function () {
        var todoTasks = [];
        var testId = "9" + (new Date()).getTime() % 10000;

        beforeEach(function (done) {
            $.ajax({url: "http://localhost:5001/Todos",
                data: JSON.stringify({ id: testId, task: "Test Task" }),
                success: function () {
                    console.info("Posted before delete");
                    $.ajax({
                        url: "http://localhost:5001/Todos/" + testId,
                        type: "DELETE",
                        success: function() {
                            $.get("http://localhost:5001/Todos", function(data) { todoTasks = data; })
                                .always(function() { done(); })
                        },
                        error: function(err) {
                            console.info("ERROR: " + JSON.stringify(err));
                        }
                    });
                },
                contentType: "application/json; charset=UTF-8",
                type: "POST",
                error: function (err) {
                    console.info("ERROR: " + JSON.stringify(err));
                }
            });
        });

        it("removes data", function () {
            console.info(todoTasks);
            var retrievedTask = _.findWhere(todoTasks, { id: testId });
            expect(retrievedTask).toBe(undefined);
        });
    });
});