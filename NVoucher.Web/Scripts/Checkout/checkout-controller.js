registrationModule.controller("CheckoutController", function ($scope, checkoutRepository) {
    $scope.results = checkoutRepository.get();
});