(function () {
    var app = angular.module('bookStore', []);

    app.directive('bookList', function () {
        return {
            restrict: 'E',
            templateUrl: 'Scripts/Custom/templates/book-list.html'
        };
    });

    app.directive('bookUpdateForm', function () {
        return {
            restrict: 'E',
            templateUrl: 'Scripts/Custom/templates/book-update-form.html'
        };
    });

    app.controller('StoreController', ['$http', '$scope', '$location', '$anchorScroll',
        function ($http, $scope, $location, $anchorScroll) {
            $scope.showBooks = true;
            $scope.books = [];
            $http.get('/api/book').then(function successCallback(response) {
                var data = response.data;
                console.log(data);
                $scope.books = data;
            });

            $scope.showBookUpdateForm = false;
            $scope.book = {};
            $scope.editBook = function (id) {
                $scope.showBookUpdateForm = true;
                $scope.book = $scope.books[id - 1];

                $location.hash('editBookForm');
                $anchorScroll();
            };

            $scope.editBookSubmit = function () {
                $http({
                    method: 'PUT',
                    url: '/api/book/' + $scope.book.Id,
                    data: $scope.book
                });
        };
    }]);
})();