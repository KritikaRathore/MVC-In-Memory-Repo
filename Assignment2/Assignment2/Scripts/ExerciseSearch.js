function SearchExercise() {
    var searchInput = document.getElementById('myInput').value;
    //alert(searchInput);
    $.post('Home/Index', { 'searchString': searchInput }, function (data, status)
    {
        $('#viewBody').html(data);
    })
}
$(function () {
    $(".addNewExercise").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var options = { "backdrop": "static", keyboard: true };
        $.ajax({
            type: "GET",
            url: '/Home/Create',
            contentType: "application/json; charset=utf-8",
            datatype: "json",
            success: function (data) {
                debugger;
                $('#myModalContent').html(data);
                $('#myModal').modal(options);
                $('#myModal').modal('show');

            },
            error: function () {
                alert("Dynamic content load failed.");
            }
        });
    });   

    $("#closbtn").click(function () {
        $('#myModal').modal('hide');
    });
});

$(function () {
    $(".addExercise").click(function () {
        debugger;
        var $buttonClicked = $(this);
        var options = { "backdrop": "static", keyboard: true };
        if($('#ExerciseName').val() == '' ||$('#ExerciseDate').val() == '' || $('#DurationInMinutes').val() == 0) {
            alert("All field values are required");
        } else if ($('#ExerciseName').length > 100 ) {
            alert("Only 100 characters allowed in Exercise Name");
        } else if ($('#DurationInMinutes').val() > 120) {
            alert("Duration in minutes cant be greater than 120");
        }else{
            var obj = JSON.stringify({ 'ExerciseName': $('#ExerciseName').val(), 'ExerciseDate': $('#ExerciseDate').val(), 'DurationInMinutes': $('#DurationInMinutes').val() });
            $.ajax({
                type: "POST",
                url: '/Home/ValidateCreate',
                data: obj,
                contentType: "application/json; charset=utf-8",
                datatype: "json",
                success: function (data) {
                    //alert("Success");
                    debugger;
                    $('#myModalContent').html(data);
                    $('#myModal').modal(options);
                    $('#myModal').modal('show');
                    $('#Addbtn').removeAttr('disabled');
                },
                error: function () {
                    alert("Oops Data is not correct! This Exercise Exist for this Date");
                    $('#myModalContent').html(data);
                    $('#myModal').modal(options);
                    $('#myModal').modal('show');
                }
            });
        }
    });

        $("#closbtn").click(function () {
            $('#myModal').modal('hide');
        });
});
