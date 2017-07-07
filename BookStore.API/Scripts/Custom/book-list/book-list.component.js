var appModule = angular.module('bookList');

appModule
    .component('bookList', {
        templateUrl: 'Scripts/Custom/templates/book-list.html',
        controller: ['$http', '$scope',
            function BookListController($http, $scope) {
                $scope.showBooks = true;
                $scope.books = [];

                function updateBookList() {
                    $http({
                        method: 'GET',
                        url: '/api/book'
                    }).then(function successCallback(response) {
                        $scope.books = response.data;
                    });
                }
                
                updateBookList();

                $scope.show = {};
                $scope.show.showBookUpdateForm = false;
                $scope.show.showSuccessMsg = false;
                $scope.show.successMsg = '';
                $scope.book = {};
                $scope.editBook = function (id) {
                    $scope.show.showBookUpdateForm = true;
                    $scope.show.showSuccessMsg = false;
                    $scope.book = $scope.books[id - 1];

                    var el = document.getElementById('editBookForm');
                    el.scrollIntoView();
                };

                $scope.deleteBook = function (id){
                    $http({
                        method: 'DELETE',
                        url: '/api/book/' + id
                    }).then(function successCallback(){
                        updateBookList();
                    });
                }

            }]
    });

appModule
    .component('bookUpdateForm', {
        templateUrl: 'Scripts/Custom/templates/book-update-form.html',
        controller: ['$http', '$scope',
            function BookUpdateFormController($http, $scope) {
                this.$onChanges = function (changesObj) {
                    $scope.book = this.book;
                    $scope.show = this.show;
                };

                $scope.editBookSubmit = function () {
                    $http({
                        method: 'PUT',
                        url: '/api/book/' + $scope.book.Id,
                        data: $scope.book
                    }).then(function successCallback(response) {
                        $scope.show.showBookUpdateForm = false;
                        $scope.show.showSuccessMsg = true;
                        $scope.show.successMsg = 'Book changed successfully.';
                    });
                };
            }],
        bindings: {
            book: '<',
            show: '<'
        }
    });

appModule
    .component('messageSuccess', {
        templateUrl: 'Scripts/Custom/templates/message-success.html',
        bindings: {
            message: '='
        }
    });