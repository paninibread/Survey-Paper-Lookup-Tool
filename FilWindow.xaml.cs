using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pls_work
{
    /// <summary>
    /// Interaction logic for FilWindow.xaml
    /// </summary>
    public partial class FilWindow : Window
    {
        string q1;
        public FilWindow()
        {
            InitializeComponent();
        }

        public string constructQuery (string query, string searchtext)
        {


            if ((bool)chkTopic.IsChecked)
            {
                query += ", Topic";
            }

            if ((bool)chkAuthors.IsChecked)
            {
                query += ", Authors";
            }

            if ((bool)chkLAuthor.IsChecked)
            {
                query += ", [Last Author]";
            }

            if ((bool)chkPublisher.IsChecked)
            {
                query += ", Publisher";
            }

            if ((bool)chkYear.IsChecked)
            {
                query += ", Year";
            }

            if ((bool)chkConference.IsChecked)
            {
                query += ", [Conference or Journal]";
            }

            if ((bool)chkKeyWords.IsChecked)
            {
                query += ", [Key Words]";
            }

            if ((bool)chkARVR.IsChecked)
            {
                query += ", [AR or VR]";
            }

            if ((bool)chkHardware.IsChecked)
            {
                query += ", Hardware";
            }

            if ((bool)chkSoftware.IsChecked)
            {
                query += ", Software";
            }

            if ((bool)chkUsers.IsChecked)
            {
                query += ", [No of Users]";
            }

            if ((bool)chkDisplay1.IsChecked)
            {
                query += ", [Display 1]";
            }

            if ((bool)chkDisplay2.IsChecked)
            {
                query += ", [Display 2]";
            }

            if ((bool)chkAnnotator.IsChecked)
            {
                query += ", Annotator";
            }

            if ((bool)chkSysName.IsChecked)
            {
                query += ", [System Name]";
            }

            if ((bool)chkInput.IsChecked)
            {
                query += ", [Input Devices]";
            }

            if ((bool)chkAnnotationForm.IsChecked)
            {
                query += ", [Annotation Form]";
            }

            if ((bool)chkCollaborationType.IsChecked)
            {
                query += ", [Collaboration Type]";
            }

            if ((bool)chkCollaborationModal.IsChecked)
            {
                query += ", [Collaboration Modality]";
            }

            if ((bool)chkExperiment.IsChecked)
            {
                query += ", Experiment";
            }

            if ((bool)chkIndoor.IsChecked)
            {
                query += ", [Outdoor or Indoor]";
            }

            if ((bool)chkTask.IsChecked)
            {
                query += ", Task";
            }

            if ((bool)chkParticipants.IsChecked)
            {
                query += ", Participants";
            }

            return query;

        }

        private void setfilter()
        {
            q1 = null;
            
            if ((bool)chkTopic.IsChecked)
            {
                q1 += ", Topic";
            }

            if ((bool)chkAuthors.IsChecked)
            {
                q1 += ", Authors";
            }

            if ((bool)chkLAuthor.IsChecked)
            {
                q1 += ", [Last Author]";
            }

            if ((bool)chkPublisher.IsChecked)
            {
                q1 += ", Publisher";
            }

            if ((bool)chkYear.IsChecked)
            {
                q1 += ", Year";
            }

            if ((bool)chkConference.IsChecked)
            {
                q1 += ", [Conference or Journal]";
            }

            if ((bool)chkKeyWords.IsChecked)
            {
                q1 += ", [Key Words]";
            }

            if ((bool)chkARVR.IsChecked)
            {
                q1 += ", [AR or VR]";
            }

            if ((bool)chkHardware.IsChecked)
            {
                q1 += ", Hardware";
            }

            if ((bool)chkSoftware.IsChecked)
            {
                q1 += ", Software";
            }

            if ((bool)chkUsers.IsChecked)
            {
                q1 += ", [No of Users]";
            }

            if ((bool)chkDisplay1.IsChecked)
            {
                q1 += ", [Display 1]";
            }

            if ((bool)chkDisplay2.IsChecked)
            {
                q1 += ", [Display 2]";
            }

            if ((bool)chkAnnotator.IsChecked)
            {
                q1 += ", Annotator";
            }

            if ((bool)chkSysName.IsChecked)
            {
                q1 += ", [System Name]";
            }

            if ((bool)chkInput.IsChecked)
            {
                q1 += ", [Input Devices]";
            }

            if ((bool)chkAnnotationForm.IsChecked)
            {
                q1 += ", [Annotation Form]";
            }

            if ((bool)chkCollaborationType.IsChecked)
            {
                q1 += ", [Collaboration Type]";
            }

            if ((bool)chkCollaborationModal.IsChecked)
            {
                q1 += ", [Collaboration Modality]";
            }

            if ((bool)chkExperiment.IsChecked)
            {
                q1 += ", Experiment";
            }

            if ((bool)chkIndoor.IsChecked)
            {
                q1 += ", [Outdoor or Indoor]";
            }

            if ((bool)chkTask.IsChecked)
            {
                q1 += ", Task";
            }

            if ((bool)chkParticipants.IsChecked)
            {
                q1 += ", Participants";
            }
            
        }

        public string searchcriteria(string searchquery, string searchtext)
        {
            if ((bool)chkLAuthor.IsChecked)
            {
                searchquery += " OR [Last Author] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkAuthors.IsChecked)
            {
                searchquery += " OR Authors LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkPublisher.IsChecked)
            {
                searchquery += " OR Publisher LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkYear.IsChecked)
            {
                searchquery += " OR Year LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkConference.IsChecked)
            {
                searchquery += " OR [Conference or Journal] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkKeyWords.IsChecked)
            {
                searchquery += " OR [Key Words] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkTopic.IsChecked)
            {
                searchquery += " OR Topic LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkARVR.IsChecked)
            {
                searchquery += " OR [AR or VR] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkHardware.IsChecked)
            {
                searchquery += " OR Hardware LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkSoftware.IsChecked)
            {
                searchquery += " OR Software LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkUsers.IsChecked)
            {
                searchquery += " OR [No of Users] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkDisplay1.IsChecked)
            {
                searchquery += " OR [Display 1] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkDisplay2.IsChecked)
            {
                searchquery += " OR [Display 2] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkAnnotator.IsChecked)
            {
                searchquery += " OR Annotator LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkSysName.IsChecked)
            {
                searchquery += " OR [System Name] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkInput.IsChecked)
            {
                searchquery += " OR [Input Devices] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkAnnotationForm.IsChecked)
            {
                searchquery += " OR [Annotation Form] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkCollaborationType.IsChecked)
            {
                searchquery += " OR [Collaboration Type] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkCollaborationModal.IsChecked)
            {
                searchquery += " OR [Collaboration Modality] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkExperiment.IsChecked)
            {
                searchquery += " OR Experiment LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkIndoor.IsChecked)
            {
                searchquery += " OR [Outdoor or Indoor] LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkTask.IsChecked)
            {
                searchquery += " OR Task LIKE '%" + searchtext + "%'";
            }

            if ((bool)chkParticipants.IsChecked)
            {
                searchquery += " OR Participants LIKE '%" + searchtext + "%'";
            }
            
            return searchquery;
        }

        private void okBtn(object sender, RoutedEventArgs e)
        {
            setfilter();
            string q2 = "SELECT Id" + q1 + " FROM primaryinfo";
            MainWindow mainWindow = Owner as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.updategrid(q2);
            }
            Hide();
        }
        private void canBtn(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
