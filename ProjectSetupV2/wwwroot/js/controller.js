(function () {
    'use strict';

    angular
        .module('app')
        .controller('sample', function ($scope, $http) {

            // $http.get(); for http calls

            $scope.text1 = 0;
            $scope.text2 = 0;

            $scope.testFunc = function () {
                $scope.text1++;
                $scope.text2  +=  2;
            };
        })

        .controller('projectForm', function ($scope, $http) { // you have more options to inject
            // rootScope is common between all controllers
            
            $scope.checkSelected = function (a, b) {
                console.log(122, a, b);

            };

            $scope.unCheckSelected = function (a, b) {
                console.log(142, a, b);

            };

            $scope.getJobs = function () {
                console.log("value", $scope.jobDescription); // check this
                $http.get(getJobUrl + "?id=" + $scope.jobDescription) // or whatever the url is
                    .then(function (response) {
                        
                        $scope.jobs = response.data; // this is your json, not response itself
                       // $scope.job = response.id;//i don't have any idea what i am doing
                    });
            };

            $scope.getTask = function (himself, id) {
                console.log(2143, $(himself).prop("checked"), id);
                //console.log(333, job.isChecked); // job isn't valid so will not work
                    $http.get(getTaskUrl + "?id=" + id) // or whatever the url is
                        .then(function (response) {
                            console.log(response);
                            $scope.tasks= response.data; // this is your json, not response itself
                        });
            };
        });

})();
