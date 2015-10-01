(function () {
    var pdfApp = angular.module('pdfApp');

    var homeController = pdfApp.controller('HomeController', ["$scope", "Upload", "$q",
        function ($scope, Upload, $q) {
        console.log("Home!");

        $scope.uploadFileToUrl = function () {

            var file = $scope.file;

            console.log("file: "+ file);

            if (file) {
                console.log("uploading file");

                var deferred = $q.defer();
                Upload.upload({
                    url: "Home/ConvertImageToPDF",
                    file: file
                })
                .success(function (data, status, headers, config) {
                    console.log("SUCCESS");
                    deferred.resolve(data);
                    
                    var file = new Blob([data], {
                        type: 'application/pdf'
                    });
                    //trick to download store a file having its URL
                    var fileURL = URL.createObjectURL(file);
                    var a = document.createElement('a');
                    a.href = fileURL;
                    a.target = '_blank';
                    a.download = 'yourfilename.pdf';
                    document.body.appendChild(a);
                    a.click();

                    //var result = new Blob([data], { type: 'application/pdf' });
                    //saveAs(result, "result.pdf");
                });
            }
           
        }
    }]);

})();