import Expo from "expo"
import React from 'react'
import { Root, Container, Header, Tab, Tabs, Title, StyleProvider } from 'native-base'
import getTheme from './native-base-theme/components'
import material from './native-base-theme/variables/material'
import Todo from './pages/todo/todo'
import Complete from './pages/complete/complete'

export default class App extends React.Component {

  constructor() {
    super()
    this.state = {
      isReady: false
    }
  }

  async componentWillMount() {
    await Expo.Font.loadAsync({
      Roboto: require("native-base/Fonts/Roboto.ttf"),
      Roboto_medium: require("native-base/Fonts/Roboto_medium.ttf")
    })

    this.setState({ isReady: true })
  }

  render() {

    if (!this.state.isReady) return <Expo.AppLoading />

    return (
      <Root>
        <StyleProvider style={getTheme(material)}>
          <Container>
            <Header hasTabs>
              <Title>Task Manager</Title>
            </Header>
            <Tabs initialPage={0}>
              <Tab heading="Todo">
                <Todo />
              </Tab>
              <Tab heading="Complete">
                <Complete />
              </Tab>
            </Tabs>
          </Container>
        </StyleProvider>
      </Root>
    )
  }
}
