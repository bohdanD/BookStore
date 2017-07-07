angular
    .module('addForm')
    .component('addForm', {
        templateUrl: 'Scripts/Custom/templates/book-add-form.html',
        controller: ['$http', '$scope',
            function AddFormController($http, $scope) {
                $scope.authors = [];
                $http({
                    method: 'GET',
                    url: '/api/author'
                }).then(function successCallback(response) {
                    $scope.authors = response.data;
                });

                function resetBook() {
                    $scope.book = {
                        Name: '',
                        Author: {},
                        Year: 2017,
                        Price: 0
                    };
                };

                resetBook();

                $scope.addBookSubmit = function () {
                    $http({
                        method: 'POST',
                        url: '/api/book',
                        data: $scope.book
                    }).then(function successCallback() {
                        resetBook();
                    });
                }
            }]
    });