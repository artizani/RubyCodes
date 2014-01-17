'use strict';

registrationModule.controller("AccountController", function ($scope, accountRepository, $location) {

    $scope.profile = {};

    $scope.submit = function (profile) {
        console.log(profile.email);
        $scope.error = false;
        accountRepository.save(profile, function(){ });
        $location.absUrl('/');

    };
});