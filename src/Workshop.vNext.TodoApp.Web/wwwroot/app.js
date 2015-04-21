var todoApp = angular.module('todoApp', []);

todoApp.controller("TodoController", function ($scope, $http) {
    $scope.newTodoTask = "";

    $http.get("/Todos").success(function(data) {
        $scope.todos = data;
    })

    $scope.markAsDone = function(todoToRemove) {
        $http.delete("/Todos/" + todoToRemove.id).success(function(data) {
            $scope.todos = $scope.todos.filter(function(todo) {
                return todo.task != todoToRemove.task;
            });
        });
    };

    $scope.addNewTodo = function() {
       
        $http.post("/Todos", { id: (new Date()).getTime() % 10000, task: $scope.newTodoTask }).success(function() {
             $scope.todos.push({ task: $scope.newTodoTask });
             $scope.newTodoTask = "";
        });
        
    };
});