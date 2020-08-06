import React, { Component } from 'react'
import ReactDOM from 'react-dom'
import api from '../Services/Api'
import App from '../App';
import Learn from './Learn' 

class Question extends Component {
    constructor() {
        super();
        this.state = {};
    }

    async componentDidMount(){
        const food = await api.get("")
        this.setState(food.data)
    }

    handleYesButtonClick = async (e) => {
        e.preventDefault();
        if(this.state.idLeft){
            var food = await api.get(this.state.idLeft)
            this.setState(food.data);
            return
        }
        alert(`Eu acertei, você pensou em ${this.state.name}`)
        ReactDOM.render(
            <App></App>,
            document.getElementById("root")
        )
    }
    
    handleNoButtonClick = async (e) => {
        e.preventDefault();
        if(this.state.idRight){
            var food = await api.get(this.state.idRight)
            this.setState(food.data);
            return
        }
        ReactDOM.render(
            <Learn foodParent={this.state}></Learn>,
            document.getElementById("root")
        )
    }
    handleQuestion = () =>{
        if(this.state.idLeft === null)
            return `Você pensou é um(a) ${this.state.name} !`
        return `A comida que você pensou é um(a) ${this.state.name} ?`
    }
    render() {
        return ( <div>
        <label>{this.handleQuestion()}</label><br/>
        <button class="btn btn-success" onClick={this.handleYesButtonClick}> Sim </button><span/>
        <button class="btn btn-danger" onClick={this.handleNoButtonClick}> Não </button>
    </div>)}
}

export default Question