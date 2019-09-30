import React from 'react';
import { Form } from 'semantic-ui-react'
import { InputField } from 'react-semantic-redux-form' 
import { Field } from 'redux-form'
import { Button } from 'semantic-ui-react'

export const FormInput = props => <Form.Input
                type={ props.hasPassword === true ? "password" : 'input' } 
                {...props.input} 
                placeholder={props.placeholder} 
                width={props.width} 
            />;

export class RenderAndAddTags extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            tagValue : ""
        }
    }

    handleChange = ({target: {value}}) => {
        this.setState({
            tagValue : value
        })
    }

    handleKeyPress = (event, fields) => {
        if (event.key === "Enter") {
            event.preventDefault();
            this.handlePushAndClear(fields);
        }
    }

    handlePushAndClear = (fields) => {
        let val = this.state.tagValue;
        let arr = fields.getAll();

        if(val==="" || (arr!==undefined && arr.indexOf(val)!==-1)) return;

        fields.push(val.toLowerCase());
        
        this.setState({
            tagValue : ""
        })
    }

    render() {
        let { fields } = this.props;

        return (
            <div>
                <Form.Group grouped>
                    {fields.map((member, index)=>{
                        return(
                                <Button 
                                    basic 
                                    key={"l"+index}
                                    onClick={()=>fields.splice(index, 1)}
                                >
                                    {fields.getAll()[index]}
                                </Button>
                        //<Form.Input name={member} key={"l"+index} placeholder={fields.getAll()[index]} id={index} component={<div><Button></Button></div>}/>
                    )})}
                
                </Form.Group>
                <Form.Group inline>
                    <Form.Input type="text" 
                        value={this.state.tagValue} 
                        onChange={this.handleChange} 
                        onKeyPress={(event)=>{this.handleKeyPress(event, fields)}}/>
                    <Button type="button" onClick={(event)=>{this.handlePushAndClear( fields)}}>Add tag</Button>
                </Form.Group>
            </div>
        )
    }
} 