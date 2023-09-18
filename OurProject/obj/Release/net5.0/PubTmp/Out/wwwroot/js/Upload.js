function fileSelectedChanged(control, btn, target, Path,input) {
    $('#' + btn).prop('disabled', true);
    //UploadProgress
    var files = $(control).get(0).files;
    if (files.length > 0) {
        var data = new FormData();
        for (i = 0; i < files.length; i++) {
            data.append("files", files[i]);
        }
        $.ajax({
            xhr: function () {
                var xhr = new window.XMLHttpRequest();
                xhr.upload.addEventListener("progress", function (evt) {
                    if (evt.lengthComputable) {
                        var percentComplete = (evt.loaded / evt.total) * 100;
                        console.log(percentComplete);
                        //$(control).prev().find('.UploadProgress').css('width', percentComplete + '%');
                        if (percentComplete === 100) {
                        }
                    }
                }, false);
                return xhr;
            },
            contentType: false,
            processData: false,
            type: 'POST',
            url: "/Uploader/PostAsyncFile?path=" + Path,
            data: data,
            success: function (data) {
                $('#' + btn).prop('disabled', false);
                $(control).prev().find('.UploadProgress').css('width', 'unset');
                if (data == null) {
                    ErrorMsg("malicious file detected, please scan your files, only only image / pdf files are allowed");
                }
                controlArr = target;
                $('#' + target).attr('src', data)
                $('#' + input).val(data)
                /*Save Image*/
                $("#oldImage").attr('value', data);
                $("#image").attr('src', data);
                $("#imagePreview").attr('src', data);
                
            },
            error: function () {
                $('#' + btn).prop('disabled', false);
                //$(control).prev().find('.UploadProgress').css('width', 'unset');
                ErrorMsg("Error Uploding please try again");
            }
        });
    }
}