var registrationModule = angular.module("resultModule", ['ngRoute', 'ngResource'])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.when('/voucher', { templateUrl: '/templates/voucher.html', controller: 'ResultController' });
        $routeProvider.when('/balance', { templateUrl: '/templates/balance.html', controller: 'InstructorController' });
        $routeProvider.when('/products/:productSku', { templateUrl: '/templates/product.html', controller: 'StoreController' });
        $routeProvider.when('/checkout', { templateUrl: '/templates/checkout.html', controller: 'StoreController' });
        $routeProvider.when('/buy', { templateUrl: '/templates/buy.html', controller: 'StoreController' });
        $routeProvider.when('/Registration/CreateAccount', { templateUrl: '/templates/create-account.html', controller: 'AccountController' });
        $routeProvider.otherwise({ redirectTo: '/' });
        $locationProvider.html5Mode(true);
    });