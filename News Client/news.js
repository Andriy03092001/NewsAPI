

function GetAllNews() {

    fetch("https://localhost:44390/api/News", {
        method: "GET",
        headers: {
            'Content-Type': 'application/json'
        }
    }).then((response) => {
        return response.json();
    }).then((data) => {
        arrayNews = data;

        for (var i = 0; i < data.length; i++) {
            document.getElementById("listNews").innerHTML +=
                `
                <div class="card col-md-4">
                    <img height="200px" class="card-img-top"
                        src="${data[i].linkImage}"
                        alt="image's news">
                    <div class="card-body">
                        <h5 class="card-title">${data[i].title}</h5>
                        <a class="btn btn-info" href="news.html/${data[i].id}">READ MORE...</a>
                    </div>
                </div>
            `
        }
    }).catch((error) => {
        console.log(error);
    })
}


function postNews() {
    var title = document.getElementById("txtTitle").value;
    var date = document.getElementById("txtDate").value;
    var URL = document.getElementById("txtURL").value;
    var description = document.getElementById("txtDescription").value;

    var obj = {
        Title: title,
        DatePost: date,
        linkImage: URL,
        Description: description
    }

    fetch("https://localhost:44390/api/News/postNews/", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    }).then((data) => {
        if (data.status == 200) {
            alert("News added!");
            document.getElementById("listNews").innerHTML = "";
            GetAllNews();
        }
        else {
            alert("Error: Server error");
        }
    }).catch((error) => {
        alert("Error: Client error");
    })
}

GetAllNews();