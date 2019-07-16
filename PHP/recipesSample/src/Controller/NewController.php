<?php


namespace App\Controller;

use App\Entity\Recipe;
use Psr\Log\LoggerInterface;
use Symfony\Bundle\FrameworkBundle\Controller\AbstractController;
use Symfony\Component\HttpFoundation\Session\Session;
use Symfony\Component\HttpFoundation\Response;
use Symfony\Component\Routing\Annotation\Route;

class NewController extends AbstractController
{
    /**
     * @Route("/",name="app_homepage")
     */
    public function homepage()
    {
        return $this->render('home.html.twig');
    }
    /**
     * @Route("/recipes", name="app_recipes")
     */
    public function recipes()
    {
        $session = new Session();
        $recipes=$this->getDoctrine()->getRepository(Recipe::class)->findAll();
        return $this->render('recipes.html.twig', ['recipesU' => array('recipes'=>$recipes),  'ingredientsU' => array('ingredients' => $session->get('ingredients', []))]);
    }
    /**
     * @Route("/ingredients", name="app_ingredients")
     */
    public function ingredients()
    {
        $session = new Session();
        return $this->render('ingredients.html.twig', array('ingredients' => $session->get('ingredients', [])));
    }
    /**
     * @Route("/add/{id}")
     */
    public function addId($id)
    {
        $session = new Session();
        $ingredients=$session->get('ingredients', []);
        switch($id)
        {
            case 0:
                {
                    if(isset($ingredients))
                        array_push($ingredients, array("name" => "Jajka", "cnt" => 10, "type" => "Szt."));
                    else
                        $ingredients[0] = array("name" => "Jajka", "cnt" => 10, "type" => "Szt.");
                    break;
                }
            case 1:
                {
                    if(isset($ingredients))
                        array_push($ingredients, array("name" => "Mąka", "cnt" => 500, "type" => "g"));
                    else
                        $ingredients[0] = array("name" => "Mąka", "cnt" => 500, "type" => "g");
                    break;
                }
            case 2:
                {
                    if(isset($ingredients))
                        array_push($ingredients, array("name" => "Masło", "cnt" => 100, "type" => "g"));
                    else
                        $ingredients[0] = array("name" => "Masło", "cnt" => 100, "type" => "g");
                    break;
                }
            case 3:
                {
                    if(isset($ingredients))
                        array_push($ingredients, array("name" => "Cukier", "cnt" => 100, "type" => "g"));
                    else
                        $ingredients[0] = array("name" => "Cukier", "cnt" => 100, "type" => "g");
                    break;
                }
        }
        $session->set('ingredients', $ingredients);
        return $this->render('ingredients.html.twig', array('ingredients' => $session->get('ingredients', [])));
    }
}