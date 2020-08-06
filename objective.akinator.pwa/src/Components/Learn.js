import React, {Component} from 'react'
import ReactDOM from 'react-dom'
import api from '../Services/Api';
import App from '../App'

class Learn extends Component {
    
    constructor(props){
        super(props);
        this.state = { foodParent: props.foodParent, rightChoice: "", firstStep: true };
    }
    handleRightChoiceChange = (e) => {
        this.setState({ rightChoice: e.target.value })
    }

    handleFirstStepButtonClick = (e) => {
        e.preventDefault();
        this.setState({ rightCaracteristic: "", firstStep: false })
    }
    
    handleRightCaracteristicChange = (e) => {
        this.setState({ rightCaracteristic: e.target.value })
    }
    
    handleLearn = async (e) => {
        e.preventDefault()
        let food = await api.post(`learn/${this.state.foodParent.id}/right`,{
                name: this.state.rightCaracteristic
            })
        await api.post(`learn/${food.data.id}/left`,{
                    name: this.state.rightChoice
                })
        
        alert("Recomeçando Jogo!");
        ReactDOM.render(
            <App></App>,
            document.getElementById("root")
        )
    }

    render(){
        return (
        <form className="form-group">
            <label> Eu desisto...</label><br/>
            {
                this.state.firstStep ?<>
                <input placeholder="Qual comida você pensou?" id="rightChoice" 
                    value={this.state.rightChoice}
                    onChange={this.handleRightChoiceChange}></input><br/>
                <button class="btn btn-success" onClick={this.handleFirstStepButtonClick}>Ok</button></>
                :
                <>
                <p> Complete a frase: <br/>
                    {this.state.rightChoice} é um(a) (...), mas {this.state.foodParent.name} não
                </p><br/>
                <input id="rightCaracteristic" 
                    value={this.state.rightCaracteristic}
                    onChange={this.handleRightCaracteristicChange}></input><br/>
                <button class="btn btn-success" onClick={this.handleLearn}>Ok</button></>
            }
        </form>
    )}
}

export default Learn