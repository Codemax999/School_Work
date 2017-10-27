import React from 'react'
import { StyleSheet } from 'react-native'
import { Form, Item, Input, Label, Button, Text, Icon } from 'native-base'
import DateTimePicker from 'react-native-modal-datetime-picker'

export default class NewItem extends React.Component {

  // --- Constructor ---
  constructor(props) {
    super(props)
    this.state = {
      isDateTimePickerVisible: false,
      itemDate: '',
      itemDescription: '',
      isSubmitDisabled: true
    }
  }


  // --- Form ---
  validateForm = () => {

    let isFormValid = 0
    isFormValid += this.state.itemDate.length > 0 ? 0 : 1
    isFormValid += this.state.itemDescription.length > 0 ? 0 : 1

    if (isFormValid === 0) this.setState({ isSubmitDisabled: false })
    else this.setState({ isSubmitDisabled: true })
  }


  // --- Description --
  handleDescriptionChange = val => {
    this.setState(({ itemDescription: val }),
      () => this.validateForm())
  }


  // --- Date Picker ---
  showDateTimePicker = () => this.setState({ isDateTimePickerVisible: true })
  hideDateTimePicker = () => this.setState({ isDateTimePickerVisible: false })

  handleDatePicked = date => {
    this.setState(({ itemDate: date.toLocaleDateString() }),
      () => {
        this.validateForm()
        this.hideDateTimePicker()
      })
  }


  // --- Submit New Task ---
  handleNewTask = () => {

    const payload = {
      description: this.state.itemDescription,
      date: this.state.itemDate
    }

    this.props.onAddItem(payload)

    this.setState({
      itemDescription: '',
      itemDate: '',
      isSubmitDisabled: true
    })
  }


  // --- Render ---
  render() {
    return (
      <Form style={styles.form}>
        <Item stackedLabel>
          <Label>Description</Label>
          <Icon active name='ios-text-outline' />
          <Input 
            value={this.state.itemDescription} 
            onChangeText={this.handleDescriptionChange} />
        </Item>

        <Item stackedLabel>
          <Label>Due Date</Label>
          <Icon active name='ios-calendar-outline' />
          <Input 
            value={this.state.itemDate} 
            onTouchStart={this.showDateTimePicker} />
        </Item>

        <DateTimePicker
          isVisible={this.state.isDateTimePickerVisible}
          onConfirm={this.handleDatePicked}
          onCancel={this.hideDateTimePicker} />

        <Button full iconLeft warning style={styles.button}
          disabled={this.state.isSubmitDisabled} 
          onPress={this.handleNewTask}>
          <Icon active name='ios-add' style={styles.btnIcon} />
          <Text style={styles.btnText}>Add Task</Text>
        </Button>
      </Form>
    )
  }
}

const styles = StyleSheet.create({
  form: { 
    marginTop: 15 
  },
  button: {
    alignSelf: 'center',
    borderRadius: 4,
    display: 'flex',
    flexDirection: 'column',
    margin: 30,
    position: 'relative',
    width: '80%'
  },
  btnIcon: {
    alignSelf: 'flex-start',
  },
  btnText:  {
    alignSelf: 'center',
    position: 'absolute',
    textAlign: 'center'
  }
})