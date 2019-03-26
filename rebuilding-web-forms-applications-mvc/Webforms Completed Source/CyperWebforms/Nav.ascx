<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Nav.ascx.cs" Inherits="CyperWebforms.Nav" %>

<nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
    <div class="navbar-header">
        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
        </button>
        <a class="navbar-brand" style="font-size: 1.5em" href="Default.aspx">Cypher Marketing (Web Forms)</a>
    </div>
    <div class="navbar-default sidebar" role="navigation">
        <div class="sidebar-nav navbar-collapse">
            <br />
            <ul class="nav" id="side-menu">
                <li>
                    <span><i class="fa fa-edit fa-fw"></i>Messages</span>
                    <ul class="nav nav-second-level in">
                        <li>
                            <a href="ViewMessages.aspx">View Messages</a>
                        </li>
                    </ul>
                </li>
                <li>
                    <span><i class="fa fa-edit fa-fw"></i>Tasks</span>
                    <ul class="nav nav-second-level">
                        <li>
                            <a href="CreateTask.aspx">Create Task</a>
                        </li>
                        <li>
                            <a href="ViewTasks.aspx">View Tasks</a>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</nav>
