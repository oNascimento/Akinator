import React from 'react'
import ReactDOM from 'react-dom'
import Question from './Question';

export default () => {

    async function handleStartButtonClick(e){
        e.preventDefault();
        ReactDOM.render(
            <Question />,
            document.getElementById("root")
        )
    }

    return(
    <div>
        <label>Pense em uma Comida...</label><br/>
        <button className="btn btn-success" onClick={handleStartButtonClick}>Começar</button>
    </div>);
}