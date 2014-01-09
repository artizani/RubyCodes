registrationModule.controller("ResultController", function ($scope, resultRepository) {
    $scope.results = resultRepository.get();
});