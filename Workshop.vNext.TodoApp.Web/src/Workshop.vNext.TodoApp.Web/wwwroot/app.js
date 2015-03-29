var todoApp = angular.module('todoApp', []);

todoApp.controller("TodoController", function ($scope) {
    $scope.newTodoTask = "";
    $scope.todos = [
        { task: "Take garbage" },
        { task: "Drive home " },
        { task: "Find Wally" }
    ];

    $scope.markAsDone = function(todoToRemove) {
        $scope.todos = $scope.todos.filter(function(todo) {
            return todo.task != todoToRemove.task;
        });
    };

    $scope.addNewTodo = function() {
        $scope.todos.push({ task: $scope.newTodoTask });
        $scope.newTodoTask = "";
    };
});