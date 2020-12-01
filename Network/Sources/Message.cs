﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public interface Message
    {
        string ToString();
    }

    [Serializable]
    public class Request : Message // all messages sent by the client and received bu the server
    {
        private string purpose;    // connection, topics, public message on topic, private message, conversation
        private string target;     // user or topic name
        private string message;    // if there is a message


        public Request(string p, string m)
        {
            purpose = p;
            message = m;
            target = null;
        }

        public Request(string p, string t, string m)
        {
            purpose = p;
            target = t;
            message = m;
        }


        public string getPurpose()
        {
            return purpose;
        }

        public string getTarget()
        {
            return target;
        }

        public string getMessage()
        {
            return message;
        }

        public override string ToString()
        {
            return purpose + " " + target + " " + message;
        }

    }

    [Serializable]
    public class Answer : Message     // all messages sent by the server and received by the client
    {
        private string title;         // name of the conversation, topic
        private List<string> content; // the list of message, topics
        private string message;       // if the message is a simple string (in general a message to print in user console)
        private bool error;

        public Answer(string tit, bool err)
        {
            title = tit;
            error = err;
            content = null;
            message = null;
        }

        public Answer(string tit, string msg, bool err)
        {
            title = tit;
            error = err;
            message = msg;
            content = null;
        }

        public Answer(string tit, List<string> cont, bool err)
        {
            title = tit;
            content = cont;
            error = err;
            message = null;
        }

        public string getTitle()
        {
            return title;
        }

        public List<string> getContent()
        {
            return content;
        }

        public string getMessage()
        {
            return message;
        }

        public bool getError()
        {
            return error;
        }

        public override string ToString()
        {
            string s = "";
            // no need to print the title, it serves only to the program

            if(content != null)
            {
                foreach (string t in content)
                {
                    s += t + " ";
                }
            }

            if (message != null)
                s += message;

            if(error)
                s += " problem in the request ! ";

            return s;
        }

    }
}