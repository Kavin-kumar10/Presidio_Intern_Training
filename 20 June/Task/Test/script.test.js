const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');

test('Pass test -> login',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'../index.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'../script.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById("email").value = "kavinkumar.prof@gmail.com";
    dom.window.document.getElementById("password").value = "kavin@10";
    dom.window.document.getElementById("login").click();
    const actual = dom.window.document.getElementById('message').innerHTML;
    expect(actual).toBe('Login successful!');
})

test('Empty test -> login',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'../index.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'../script.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById("email").value = "";
    dom.window.document.getElementById("password").value = "";
    dom.window.document.getElementById("login").click();
    const actual = dom.window.document.getElementById('message').innerHTML;
    expect(actual).toBe('Please enter both email and password.');
})

test('Fail test -> login',()=>{
    const html = fs.readFileSync(path.resolve(__dirname,'../index.html'),'utf8');
    const script = fs.readFileSync(path.resolve(__dirname,'../script.js'),'utf8');
    
    const dom = new JSDOM(html,{runScripts: 'dangerously',resources: 'usable'});
    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    dom.window.document.getElementById("email").value = "kavinkumar.rpfodslkfajl@gmail.com";
    dom.window.document.getElementById("password").value = "sadfdf";
    dom.window.document.getElementById("login").click();
    const actual = dom.window.document.getElementById('message').innerHTML;
    expect(actual).toBe('Invalid email or password.');
})

