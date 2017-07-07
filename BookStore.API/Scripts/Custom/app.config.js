angular
    .module('bookStore')
    .config(['$locationProvider', '$routeProvider',
        function ($locationProvider, $routeProvider){
            $locationProvider.hashPrefix('!');

            $routeProvider
                .when('/books', {
                    template: '<book-list></book-list>'
                })
                .when('/addBook', {
                    template: '<add-form></add-form>'
                })
                .otherwise('/books');
        }
    ]);
