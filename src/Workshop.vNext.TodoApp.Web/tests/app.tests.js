
"use strict";
describe("Todos API", function () {

	var self = this;

	function retrieveTasks(success) {
		return $.get("http://localhost:1602/Todos", function (data) {
			success(data);
		}).fail(function (err) {
			if (err.responseText && err.responseText.length > 200)
				err.responseText = "...";
			console.error("Failed retrieving task: " + JSON.stringify(err));
		});
	};

	function addTask(done, taskObject, success) {
		$.ajax({
			url: "http://localhost:1602/Todos",
			data: JSON.stringify(taskObject),
			success: function () {
				console.log("Added " + JSON.stringify(taskObject));
				success();
			},
			error: function (err) {
				if (err.responseText && err.responseText.length > 100)
					err.responseText = "...";
				console.error("Failed to add a task " + JSON.stringify(err));
				done();
			},
			contentType: "application/json; charset=UTF-8",
			type: "POST"
		});
	};

	function deleteTask(done, taskId, success) {
		$.ajax({
			url: "http://localhost:1602/Todos/" + taskId,
			type: "DELETE",
			success: function () {
				console.log("Deleted " + taskId);
				success();
			},
			error: function (err) {
				if (err.responseText && err.responseText.length > 100)
					err.responseText = "...";
				console.error("Failed to delete a task " + JSON.stringify(err));
				done();
			}
		});
	}

    describe("GET /Todos", function() {
        var todoTasks = [];

        beforeEach(function (done) {
        	retrieveTasks(function(data) {
				todoTasks = data;
			})
			.always(function() {
				done();
			});
        });

        it("returns data", function () {
        	console.info("TEST: There is at least one task");
            expect(todoTasks.length).toBeGreaterThan(0);
        });
    });


    describe("POST /Todos", function () {
        var todoTasks = [];
        var testId = (new Date()).getTime() % 10000;

        beforeEach(function (done) {
        	addTask(done, { id: testId, task: "Test Task" }, function () {
        		retrieveTasks(function (data) { todoTasks = data; })
							.always(function () { done(); });
        	});
        });

        it("adds data", function () {
        	console.info("TEST: Added task is retrieved back");
            var retrievedTask = _.findWhere(todoTasks, { id: testId });
            expect(retrievedTask.id).toBe(testId);

        });
    });

    describe("DELETE /Todos", function () {
        var todoTasks = undefined;
        var testId = "9" + (new Date()).getTime() % 10000;

        beforeEach(function (done) {
        	addTask(done, { id: testId, task: "Test Task" }, function () {
        		deleteTask(done, testId, function () {
        			retrieveTasks(function (data) { todoTasks = data; }).always(function () { done() });
        		})
        	});
        });

        it("removes data", function () {        
        	console.info("TEST: Deleted task is not retrieved");
        	var retrievedTask = _.findWhere(todoTasks, { id: testId });
        	expect(todoTasks).not.toBe(undefined);
            expect(retrievedTask).toBe(undefined);
        });
    });
});