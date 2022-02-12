// Upload files

function uploadFiles() {

    var input = document.querySelector('input[type="file"]');

    let file = input.files[0];
    let fileName = file.name;
    let newName = file.lastModified + file.name;
    let newFile = new File([fileName], newName, { type: 'image/jpeg' })
    console.log(newName);
    const formData = new FormData();
    formData.append('file', file);

    fetch("/music", {
        method: "POST",
        body: formData
    })
        .then(success => console.log("image uploaded"))
        .catch(error => console.log(error))
}