angular
    .module('bookStore')
    .config(['$locationProvider', '$routeProvider',
        function ($locationProvider, $routeProvider){
            $locationProvider.hashPrefix('!');

            $routeProvider
                .when('/books', {
                    template: '<book-list></book-list>'
                })
                .otherwise('/books');
        }
    ]);
