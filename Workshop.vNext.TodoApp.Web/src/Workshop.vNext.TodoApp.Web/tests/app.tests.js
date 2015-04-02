
"use strict";
describe("Todos API", function () {
    var todoTasks;

    beforeEach(function(done) {
        $.get("http://localhost:5001/Todos", function(data) {
            todoTasks = data;
        }).always(function() {
            done();
        });
    });

    it("should expose Todo tasks", function () {
        expect(todoTasks.length).toBeGreaterThan(0);
    });
});