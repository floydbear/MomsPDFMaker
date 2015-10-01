(function () {
    var pdfApp = angular.module('pdfApp', ['ngRoute', 'ngFileUpload']);

    pdfApp.config(['$routeProvider', function ($routeProvider) {
        
        $routeProvider
            .when('/', {
                templateUrl: '/app/Views/Home.html',
                controller: 'HomeController'
            }).otherwise({
                redirectTo: '/'
            });
    }]);


 

})();