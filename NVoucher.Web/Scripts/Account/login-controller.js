'use strict';

/*registrationModule.controller("LoginController", function ($scope, loginRepository, $location) {

    $scope.user = {};
    $scope.user.grant_type="password";
    var credentials = $scope.user;

    $scope.login = function () {
        console.log(credentials);

        $scope.error = false;
        loginRepository.save(credentials, function( data, headers){
        $scope.token = headers('Authorization');
        console.log($scope.token)
        });
        $location.absUrl('/');

    };
});*/

registrationModule.controller("LoginController", function ($scope, $http, $location, UserService) {


    $scope.user = {};
    $scope.user.grant_type="password";
    var credentials = $scope.user;
    $scope.logout = function () {

        $http.post('/api/Account/Logout');
        UserService.currentUser = null;
        return;
    };
    $scope.login = function () {

        $http({method: 'POST', url: '/token', data:  credentials , transformRequest: function (obj) {
            var str = [];
            for (var p in obj)
                str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
            return str.join("&");
        }}).success(function (data, status, headers, config) {
            $scope.output = data;
            UserService.currentUser = data.header;
                console.log(data.access_token);
            }).error(function (data, status, headers, config) {
                $scope.output = data;
            });

        $location.absUrl('/');

};
});

registrationModule.service('UserService', function($rootScope) {
    return {
        currentUser: null
    };
});