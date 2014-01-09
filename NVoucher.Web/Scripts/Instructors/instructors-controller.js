
registrationModule.controller("InstructorController", function ($scope, instructorRepository) {
    $scope.instructors = instructorRepository.get();
});
