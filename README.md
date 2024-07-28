This repo is an artifact entered into
[Pervasive AI Developer Contest with AMD](https://www.hackster.io/contests/amd2023) on [hackster.io](https://www.hackster.io/)

# The AI Enabled Operating System Ecosystem #

[See it on hackser.io!](https://www.hackster.io/rhenry74/the-ai-enabled-operating-system-ecosystem-f66272)

## What problem are you going to solve ##

The standard desktop or laptop PC operating system has no built-in way of leveraging Artificial Intelligence. Even if AI enabled productivity applications existed, they have no way of integrating themselves into an AI enabled operating system. This project attempts to provide a service to address this gap.

## What are you going to build to solve this problem? How is it different from existing solutions? Why is it useful? ##

I plan to build a service to which AI enabling applications can register their capabilities. The service will provide hooks used during installation of AI enabling applications.
 
I plan to build at least one AI enabling application. An example if an application that can be automated by AI might be an email client that provides endpoints that an AI can use to set the recipient, append the body, send the email, etc. Currently I am not aware of applications that are designed to be automated much less a specification for how they can be automated. Schemes that use camera vision to capture the screen then manipulate the mouse and keyboard are overly complex, inefficient and error prone. I also plan to build the AI enabling application's installer which is an important piece of this puzzle.

I plan to build an interface that includes chat and an action broker. The user will be able to ask an LLM to do something via chat and the LLM will be able to generate actions that can be acted on by the broker. The broker is capable of understanding when the user wants to use a registered AI enabling application, launch it and broker interaction with it.

By providing an ecosystem that supports applications that can be automated by AI this solution would open the door to users that are keen to leverage AI in daily workflow, vendors that want to create AI enabling applications and hardware manufactures providing AI support to all thrive at the Operating System level.

## How does your solution work? What are the main features? Please specify how you will use the AMD AI Hardware in your solution. ##
The broker will get an embedding for the user's phrase and match it against embeddings in a vector database. Highly ranked hits may be acted upon. The highly ranked row in the database would let the broker know where the application to launch is... or if the application is already open it may communicate some user direction to it via a binding definition.
 
The rows that define AI enabling application capabilities are added to the database when the application is installed, it's embeddings for its key phrases (actions) are generated at that time.
 
Embeddings must be generated in near real time for this to run smoothly: AMD AI hardware would certainly be used for that.
 
A modern AI enabled operating system should host a large language model that can be used for general chat. Ideally this LLM would be trained on general personal computer operating system and how to use them. AMD AI hardware should (hopefully) support this as well. This same LLM should, via artful prompt engineering, be able to generate actions to be handed off to the broker, orchestrating full workflows between multiple AI enabling applications. The broker would verify that the generated actions are syntactically correct and then potentially execute them. The LLM could learn from mistakes and successes, improve over time and become the backbone of the operating system.

AI enabling application could supply training corpuses during install. The corpus would be used to fine tune the onboard LLM to be more proficient in generating actions for the particular AI enabling app.

Additionally, it would be great if the system could run via voice command and AMD AI Hardware could support speech to text and text to speech.  

## List the hardware and software you will use to build this. ##
I am entering the AMD AI Hardware enabled (non GPU) contest and this is all the hardware required.

I will use Visual Studio Community and C# to create Windows applications in C#. 

I plan to use PostgreSQL database with vector support, but if there is a better vector database option that will run on AMD AI Hardware I may utilize it.

I will use Python to build services close to the AMD hardware and consume them with C#. I have experience with Windows inter-process communication.

Obviously, I will have to come up to speed on AMD SDKs for 7040 series NPUs.

## Tell us about yourself. What do you spend most of your time doing? What skills or experience do you have that will enable you to be successful in building this project? ##
I am a software team lead and former developer with over 30 years of experience with software development. In my spare time I have enjoyed programming microprocessors like the ESP32. My interest in AI is relatively new.
 
I do have experience with native Windows UI applications, Windows services, relational databases and Windows installers. I plan to use these skills to build applications, that I am familiar with building, around the new, less familiar, AI related technology stack. 
