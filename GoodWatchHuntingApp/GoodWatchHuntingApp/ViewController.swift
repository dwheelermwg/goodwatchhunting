//
//  ViewController.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/9/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    
    let healthManager:HealthManager = HealthManager()
    
    func authorizeHealthKit(){
        healthManager.authorizeHealthKit { (authorized,  error) -> Void in
            if authorized {
                print("HealthKit authorization received.")
            }
            else
            {
                print("HealthKit authorization denied!")
                if error != nil {
                    print("\(error)")
                }
            }
        }
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        
        authorizeHealthKit()
        healthManager.queryHeartRate()
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
}

