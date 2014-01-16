'use strict';

registrationModule.controller("AccountController", function ($scope, accountRepository, $location) {

    $scope.profile = {};

 

    $scope.submit = function (profile) {
        console.log(profile.email);
        $scope.error = false;
        accountRepository.save(profile).$promise.then(
            function() { $location.absUrl('/store'); },
            function() { $scope.error = true; });
    };
});