function SayHi(name)
{
    alert("Hi there " + name);

    return "some hi";
};

function ReturnData(num)
{

    alert("Data!");

    var arrayNum = [];
    for (var i = 0; i < num; i++)
        arrayNum.push(i);

    return "something data";
};

function GotoAnother(otherUrl)
{
    window.location.replace(otherUrl);
}
