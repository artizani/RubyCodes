var registrationModule = angular.module("resultModule", ['ngRoute', 'ngResource'])
    .config(function($routeProvider, $locationProvider) {
        $routeProvider.when('/Result', { templateUrl: '/templates/results.html', controller: 'ResultController' });
        $routeProvider.when('/Instructors', { templateUrl: '/templates/instructors.html', controller: 'InstructorController' });
        $routeProvider.when('/Registration/CreateAccount', { templateUrl: '/templates/create-account.html', controller: 'AccountController' });
        $locationProvider.html5Mode(true);
    });